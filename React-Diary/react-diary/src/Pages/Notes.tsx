import { Button } from "@material-ui/core";
import React, { useEffect, useState } from "react";
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
    <div className="my-notes">
      <h1>MY NOTES</h1>
      <Box isGrey={true}>
        <table>
          {notes.map((note: INotes) => (
            <tr>
              <td>
                <NavLink key={note.id} exact to={`notes/${note.noteURL}`}>
                  {note.noteName}
                </NavLink>
              </td>
              <td>
                <Button
                  variant="contained"
                  color="secondary"
                  onClick={() => onDelete(note.id)}
                >
                  Delete Note
                </Button>
              </td>
            </tr>
          ))}
        </table>

        <NavLink to="new-note">
          <Button variant="contained" color="primary">
            New Note
          </Button>
        </NavLink>
      </Box>
    </div>
  );
};

export default Notes;
