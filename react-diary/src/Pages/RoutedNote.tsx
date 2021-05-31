import React, { useEffect, useState } from "react";
import ReactMarkdown from "react-markdown";
import Box from "../Components/Box";
import { INote } from "../Components/Interfaces";
import { getNoteContent } from "../Components/TodayRecentQuickNote";

const RoutedNote: React.FC<{ match: any }> = (props) => {
  const [noteContent, setNoteContent] = useState<INote[]>([]);

  useEffect(() => {
    const getNotes = async () => {
      const getNoteContentFromServer = await getNoteContent();
      setNoteContent(getNoteContentFromServer);
    };

    getNotes();
  }, []);

  console.log(noteContent);

  let actualNote = noteContent.find((note: INote) => {
    return props.match.params.id == note.noteURL;
  });

  if (!actualNote) {
    actualNote = {
      noteName: "",
      noteURL: "",
      noteContent: "",
      id: 0,
    };
  }

  console.log(props.match.params.id);

  return (
    <>
      {props.match.isExact && (
        <div className="routed-note">
          <h1>{actualNote.noteName}</h1>
          <Box isGrey={true}>
            <ReactMarkdown>{actualNote.noteContent}</ReactMarkdown>
          </Box>
        </div>
      )}
    </>
  );
};

export default RoutedNote;
