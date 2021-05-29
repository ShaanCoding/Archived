import { useState } from "react";
import { FaPencilAlt, FaBookOpen, FaCogs } from "react-icons/fa";
import { NavLink } from "react-router-dom";

const favourites = [
  {
    name: "Journal - April",
    url: "journal",
  },
  {
    name: "Finances",
    url: "finances",
  },
  {
    name: "Home Tasks",
    url: "home-tasks",
  },
  {
    name: "Books to Read",
    url: "books-to-read",
  },
  {
    name: "Travel List",
    url: "travel-list",
  },
];

const SideBar: React.FC = (props) => {
  const [openNav, setOpenNav] = useState(false);

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
          <div className="line-box">
            {/* Fix */}
            <p className="line-text">DASHBOARD</p>

            <ul>
              <li>
                <NavLink exact to="/">
                  DASHBOARD
                </NavLink>
              </li>
              <li>
                <NavLink exact to="/quick-note">
                  QUICK NOTE
                </NavLink>
              </li>
              <li>
                <NavLink exact to="/journal">
                  JOURNAL
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
              <li>
                <NavLink exact to="/calendar">
                  CALENDAR
                </NavLink>
              </li>
            </ul>
          </div>

          {/* Favourites */}
          <div className="line-box">
            {/* Fix */}
            <p className="line-text">FAVOURITES</p>

            <ul>
              {favourites.map((favourite) => (
                <li>
                  <NavLink exact to={favourite.url}>
                    {favourite.name}
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
          {/* Settings */}
          <div>
            <NavLink exact to="/settings">
              <FaCogs />
              Settings
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
