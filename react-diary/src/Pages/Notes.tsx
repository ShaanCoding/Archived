import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import Box from "../Components/Box";
import { INotes } from "../Components/Interfaces";
import {
  deleteRealNotes,
  fetchRealNotes,
} from "../Components/TodayRecentQuickNote";

const Notes: React.FC = (props) => {
  const [notes, setNotes] = useState<INotes[]>([]);

  useEffect(() => {
    const getNotes = async () => {
      const getNotesFromServer = await fetchRealNotes();
      setNotes(getNotesFromServer);
    };

    getNotes();
  }, []);

  const onDelete = (id: number) => {
    deleteRealNotes(notes, setNotes, id);
  };

  return (
    <Box isGrey={true}>
      <h1>My Notes</h1>
      {notes.map((note: INotes) => (
        <li>
          <NavLink key={note.id} exact to={`notes/${note.noteURL}`}>
            {note.noteName}
          </NavLink>
          <button onClick={() => onDelete(note.id)}>Delete Note</button>
        </li>
      ))}

      <NavLink to="new-note">New Note</NavLink>
    </Box>
  );
};

export default Notes;
