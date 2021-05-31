import React, { useEffect, useState } from "react";
import ReactMarkdown from "react-markdown";
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
        <>
          <h1>{actualNote.noteName}</h1>
          <ReactMarkdown>{actualNote.noteContent}</ReactMarkdown>
        </>
      )}
    </>
  );
};

export default RoutedNote;
