import React, { useEffect } from "react";
import { IQuickNote } from "../Components/Interfaces";
import {
  fetchQuickNotes,
  serverSetQuickNotes,
} from "../Components/TodayRecentQuickNote";
import SimpleMDE, { SimpleMdeReact } from "react-simplemde-editor";

const QuickNote: React.FC = (props) => {
  const [quickNotes, setQuickNotes] = React.useState<IQuickNote>({ name: "" });

  useEffect(() => {
    const getQuickNotes = async () => {
      const getQuickNotesFromServer = await fetchQuickNotes();
      setQuickNotes(getQuickNotesFromServer);
    };

    getQuickNotes();
  }, []);

  const onChange = (value: string) => {
    setQuickNotes({ name: value });
    serverSetQuickNotes(quickNotes);
  };

  return (
    <div className="quickNote">
      <SimpleMdeReact value={quickNotes.name} onChange={onChange} />
    </div>
  );
};

export default QuickNote;
