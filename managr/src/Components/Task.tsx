import { Button } from "@material-ui/core";
import React, { useState } from "react";
import { setSyntheticLeadingComments } from "typescript";
import TaskData from "./TaskData";

const Task: React.FC<{ task: TaskData; onDelete: () => void }> = (props) => {
  //Make prop for done or undone
  const [done, setDone] = useState(false);

  return (
    <div>
      <Button
        variant="contained"
        color="primary"
        onClick={() => {
          setDone(!done);
        }}
      >
        Done
      </Button>

      {/* If it is done we display the striked through one */}
      {!done ? (
        <h1>{props.task.task}</h1>
      ) : (
        <h1>
          <s>{props.task.task}</s>
        </h1>
      )}

      {/* Delete button */}
      <Button
        variant="contained"
        color="primary"
        onClick={() => {
          props.onDelete();
        }}
      >
        Delete
      </Button>
    </div>
  );
};

export default Task;
