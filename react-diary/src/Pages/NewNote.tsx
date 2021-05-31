import { Button } from "@material-ui/core";
import React, { useState } from "react";
import SimpleMdeReact from "react-simplemde-editor";
import Box from "../Components/Box";
import { INote, INotes } from "../Components/Interfaces";
import {
  addRealNotes,
  setNoteContent,
} from "../Components/TodayRecentQuickNote";

const NewNote: React.FC = (props) => {
  const [title, setTitle] = useState<string>("");
  const [content, setContent] = useState<string>("");

  const onChange = (value: string) => {
    setContent(value);
  };

  const submitForm = () => {
    // Submit title and content to form
    const newNote: INote = {
      noteName: title,
      noteURL: title.toLowerCase().replace(" ", "-"),
      noteContent: content,
      id: 0,
    };

    const newNoteTitle: INotes = {
      noteName: title,
      noteURL: title.toLowerCase().replace(" ", "-"),
      id: 0,
    };

    setNoteContent(newNote);

    // Also submit it to

    addRealNotes(newNoteTitle);
  };

  return (
    <div className="new-note">
      <h1>NEW NOTE</h1>
      <Box isGrey={true}>
        {/* Add Title */}
        <label>Title</label>
        <input type="textfield" onBlur={(e) => setTitle(e.target.value)} />
        {/* Add Content */}
        <SimpleMdeReact onChange={onChange} />
        {/* Create button */}
        <Button variant="contained" color="secondary" onClick={submitForm}>
          Submit
        </Button>
      </Box>
    </div>
  );
};

export default NewNote;
