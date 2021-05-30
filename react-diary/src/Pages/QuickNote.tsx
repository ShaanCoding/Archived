import MDEditor from "@uiw/react-md-editor";
import React from "react";

const QuickNote: React.FC = (props) => {
  const [value, setValue] = React.useState<string>("**Hello world!!!**");

  return (
    <div className="quickNote">
      <MDEditor value={value} onChange={() => setValue} />
    </div>
  );
};

export default QuickNote;
