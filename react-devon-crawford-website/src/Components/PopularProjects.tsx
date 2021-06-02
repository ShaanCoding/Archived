import axios from "axios";
import { useEffect, useState } from "react";
import { IProject } from "./Interfaces";

const PopularProjects = () => {
  const [project, setProject] = useState<IProject[]>([]);

  useEffect(() => {
    const getRepository = async () => {
      const res = await axios.get(
        "https://api.github.com/users/ShaanCoding/repos?sort=created"
      );

      const topFive: IProject[] = res.data
        .map((repository: any) => {
          return {
            projectID: repository.id,
            projectTitle: repository.name,
            projectDescription: repository.description,
            projectLanguage: repository.language,
            projectStars: repository.stargazers_count,
          };
        })
        .slice(0, 5);

      return setProject(topFive);
    };

    getRepository();
  }, []);

  return (
    <div className="center">
      <div className="popular-projects">
        <h1>Popular Projects</h1>
        {project && (
          <table>
            <tr>
              <th>Title</th>
              <th>Description</th>
              <th>Languages</th>
              <th>Stars</th>
            </tr>
            {project.map((repository: IProject) => (
              <tr key={repository.projectID}>
                <td>{repository.projectTitle}</td>
                <td>{repository.projectDescription}</td>
                <td>{repository.projectLanguage}</td>
                <td>{repository.projectStars}</td>
              </tr>
            ))}
          </table>
        )}
      </div>
    </div>
  );
};

export default PopularProjects;
