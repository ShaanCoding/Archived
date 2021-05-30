import MDEditor from "@uiw/react-md-editor";
import React, { useEffect } from "react";
import {
  fetchQuickNotes,
  serverSetQuickNotes,
} from "../Components/TodayRecentQuickNote";

const QuickNote: React.FC = (props) => {
  const [quickNotes, setQuickNotes] = React.useState<string>("");

  useEffect(() => {
    const getQuickNotes = async () => {
      const getQuickNotesFromServer = await fetchQuickNotes();
      setQuickNotes(getQuickNotesFromServer[0]);
    };

    getQuickNotes();
  }, []);

  return (
    <div className="quickNote">
      <MDEditor
        value={quickNotes}
        onChange={() => serverSetQuickNotes(quickNotes, setQuickNotes)}
      />
    </div>
  );
};

export default QuickNote;
