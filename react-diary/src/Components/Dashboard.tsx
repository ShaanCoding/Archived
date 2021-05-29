import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import Box from "./Box";

interface IRecentNotes {
  noteName: string;
  noteURL: string;
}

const Dashboard: React.FC = (props) => {
  const [recentNotes, setRecentNotes] = useState<IRecentNotes[]>([]);
  const [quickNotes, setQuickNotes] = useState<string[]>([]);

  // Fetch Recent Notes
  const fetchNotes = async () => {
    const res = await fetch("http://localhost:5000/recent-notes");
    const data = await res.json();
    return data;
  };

  // Fetch Quick Notes
  const fetchQuickNotes = async () => {
    const res = await fetch("http://localhost:5000/quick-note");
    const data = await res.json();
    return data;
  };

  useEffect(() => {
    const getNotes = async () => {
      const notesFromServer = await fetchNotes();
      setRecentNotes(notesFromServer);
    };

    const getQuickNotes = async () => {
      const getQuickNotesFromServer = await fetchQuickNotes();
      setQuickNotes(getQuickNotesFromServer);
    };

    getNotes();
    getQuickNotes();
  }, []);

  console.log(quickNotes);

  return (
    <div className="dashboard">
      <h1>DASHBOARD</h1>
      <h2>Welcome, back!</h2>

      <Box isGrey={true}>
        <h3>TODAY</h3>
        {/* Checkboxes */}
      </Box>

      <Box isGrey={false}>
        <h3>RECENT NOTES</h3>
        {/* {favourites.map((favourite) => (
                <li>
                  <NavLink exact to={favourite.url}>
                    {favourite.name}
                  </NavLink>
                </li>
              ))} */}
        {recentNotes.map((note) => (
          <li>
            <NavLink exact to={note.noteURL}>
              {note.noteName}
            </NavLink>
          </li>
        ))}
      </Box>

      <Box isGrey={true}>
        <h3>QUICK NOTE</h3>
        {quickNotes.map((quickNote) => (
          <p>{quickNote}</p>
        ))}
      </Box>
    </div>
  );
};

export default Dashboard;
