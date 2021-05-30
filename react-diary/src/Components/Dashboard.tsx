import React, { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import Box from "./Box";
import { IRecentNotes, IToday } from "./Interfaces";

const Dashboard: React.FC = (props) => {
  const [todayNotes, setTodayNotes] = useState<IToday[]>([]);
  const [recentNotes, setRecentNotes] = useState<IRecentNotes[]>([]);
  const [quickNotes, setQuickNotes] = useState<string[]>([]);

  // Fetch Today
  const fetchTodays = async () => {
    const res = await fetch("http://localhost:5000/today");
    const data = await res.json();
    return data;
  };

  const fetchToday = async (id: number) => {
    const res = await fetch(`http://localhost:5000/today/${id}`);
    const data = await res.json();
    return data;
  };

  // Update Today
  const addToday = async (newToday: IToday) => {
    const res = await fetch("http://localhost:5000/today", {
      method: "POST",
      headers: {
        "Content-type": "application/json",
      },
      body: JSON.stringify(newToday),
    });
  };

  // Toggle Today (Checkboxes)
  const toggleToday = async (id: number) => {
    // Fetch data
    const todayToToggle: IToday = await fetchToday(id);
    const updatedDay = { ...todayToToggle, isDone: !todayToToggle.isDone };

    const res = await fetch(`http://localhost:5000/today/${id}`, {
      method: "PUT",
      headers: {
        "Content-type": "application/json",
      },
      body: JSON.stringify(updatedDay),
    });

    const data: IToday = await res.json();

    setTodayNotes(
      todayNotes.map((todayNote) =>
        todayNote.id === id ? { ...todayNote, isDone: data.isDone } : todayNote
      )
    );
  };

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
          <p>
            <input
              key={today.id}
              type="checkbox"
              checked={today.isDone}
              onClick={() => toggleToday(today.id)}
            />
            {today.taskName}
          </p>
        ))}
      </Box>

      <Box isGrey={false}>
        <h3>RECENT NOTES</h3>
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
