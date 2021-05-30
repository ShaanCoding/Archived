import { useEffect, useState } from "react";
import { NavLink } from "react-router-dom";
import Box from "../Components/Box";
import { INotes } from "../Components/Interfaces";
import { fetchNotes } from "../Components/TodayRecentQuickNote";

const Notes: React.FC = (props) => {
  const [notes, setNotes] = useState<INotes[]>([]);

  useEffect(() => {
    return () => {
      const getNotes = async () => {
        const getNotesFromServer = await fetchNotes();
        setNotes(getNotesFromServer);
      };
    };
  }, []);

  console.log(notes);

  return (
    <Box isGrey={true}>
      <h1>My Notes</h1>
      {notes.map((note: INotes) => (
        <NavLink key={note.id} exact to={note.noteURL}>
          {note.noteName}
        </NavLink>
      ))}
    </Box>
  );
};

export default Notes;
