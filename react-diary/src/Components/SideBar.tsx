import { useEffect, useState } from "react";
import { FaPencilAlt, FaBookOpen, FaCogs } from "react-icons/fa";
import { NavLink } from "react-router-dom";
import { IFavourites, IRecentNotes } from "./Interfaces";
import { fetchFavourites, fetchNotes } from "./TodayRecentQuickNote";

const SideBar: React.FC = (props) => {
  const [openNav, setOpenNav] = useState(false);
  const [favourites, setFavourites] = useState<IFavourites[]>([]);

  useEffect(() => {
    const getFavourites = async () => {
      const favouritesFromServer = await fetchFavourites();
      setFavourites(favouritesFromServer);
    };

    getFavourites();
  }, []);

  return (
    <>
      {openNav ? (
        <div className="side-bar">
          <button onClick={() => setOpenNav(!openNav)}>Close</button>

          <h1>
            <FaPencilAlt />
            DIARY
          </h1>

          {/* Dashboard */}
          <div>
            {/* Fix */}
            <b>
              <NavLink exact to="/" className="line-text">
                DASHBOARD
              </NavLink>
            </b>
            <ul>
              <li>
                <NavLink exact to="/quick-note">
                  QUICK NOTE
                </NavLink>
              </li>
              <li>
                <NavLink exact to="/notes">
                  NOTES
                </NavLink>
              </li>
              <li>
                <NavLink exact to="/to-do">
                  TO-DO
                </NavLink>
              </li>
            </ul>
          </div>

          {/* Favourites */}
          <div className="line-box">
            {/* Fix */}
            <b>FAVOURITES</b>

            <ul>
              {favourites.map((favourite) => (
                <li>
                  <NavLink exact to={`notes/${favourite.favouriteURL}`}>
                    {favourite.favouriteName}
                  </NavLink>
                </li>
              ))}
            </ul>
          </div>

          {/* New Notes */}
          <div>
            <NavLink exact to="/new-note">
              <FaBookOpen />
              New Note
            </NavLink>
          </div>
        </div>
      ) : (
        <button onClick={() => setOpenNav(!openNav)}>Open</button>
      )}
    </>
  );
};

export default SideBar;
