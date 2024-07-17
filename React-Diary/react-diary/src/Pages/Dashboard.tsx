import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import Box from "../Components/Box";
import { IQuickNote, IRecentNotes, IToday } from "../Components/Interfaces";

import {
  fetchNotes,
  fetchQuickNotes,
  fetchTodays,
  toggleToday,
} from "../Components/TodayRecentQuickNote";
import { Checkbox } from "@material-ui/core";
import ReactMarkdown from "react-markdown";

const Dashboard: React.FC = (props) => {
  const [todayNotes, setTodayNotes] = useState<IToday[]>([]);
  const [recentNotes, setRecentNotes] = useState<IRecentNotes[]>([]);
  const [quickNotes, setQuickNotes] = useState<IQuickNote>({ name: "" });

  useEffect(() => {
    const getToday = async () => {
      const todayFromServer = await fetchTodays();
      setTodayNotes(todayFromServer);
    };

    const getNotes = async () => {
      const notesFromServer = await fetchNotes();
      setRecentNotes(notesFromServer);
    };

    const getQuickNotes = async () => {
      const getQuickNotesFromServer = await fetchQuickNotes();
      setQuickNotes(getQuickNotesFromServer);
    };

    getToday();
    getNotes();
    getQuickNotes();
  }, []);

  return (
    <div className="dashboard">
      <h1>DASHBOARD</h1>
      <h2>Welcome, back!</h2>

      <Box isGrey={true}>
        <h3>TODAY</h3>
        {/* Checkboxes */}
        {todayNotes.map((today) => (
          <div className="todayNotes">
            <Checkbox
              key={today.id}
              checked={today.isDone}
              onClick={() => toggleToday(todayNotes, setTodayNotes, today.id)}
            />
            {today.taskName}
          </div>
        ))}
      </Box>

      <Box isGrey={false}>
        <h3>RECENT NOTES</h3>
        {recentNotes.map((note) => (
          <li key={note.id}>
            <NavLink exact to={note.noteURL}>
              {note.noteName}
            </NavLink>
          </li>
        ))}
      </Box>

      <Box isGrey={true}>
        <h3>QUICK NOTE</h3>
        <ReactMarkdown>{quickNotes.name}</ReactMarkdown>
      </Box>
    </div>
  );
};

export default Dashboard;
