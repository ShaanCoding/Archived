import { useState } from "react";
import { ITask } from "../Interfaces";
import TaskList from "./TaskList";

const Header: React.FC<{ addTask: (task: ITask) => void }> = (props) => {
  const [task, setTask] = useState<string>("");

  return (
    <div>
      <input
        type="textfield"
        value={task}
        onChange={(e) => {
          setTask(e.target.value);
        }}
      />

      <button
        onClick={() => {
          if (task) {
            props.addTask({
              id: 5,
              isDone: false,
              taskName: task,
            });
          }
        }}
      >
        Add Task
      </button>
    </div>
  );
};

export default Header;
