import React, { useState } from "react";
import { Button, Input, TextField } from "@material-ui/core";
import TaskData from "./TaskData";

let idCounter = 0;

const Header: React.FC<{ addTask: (task: TaskData) => void }> = (props) => {
  const [task, setTask] = useState("");

  return (
    <div>
      <h1>Managr</h1>
      <TextField
        variant="outlined"
        label="Add a task"
        type="text"
        value={task}
        onChange={(e) => {
          setTask(e.target.value);
        }}
      />

      <Button
        variant="contained"
        color="primary"
        onClick={() => {
          //We need a callback function to the main class and then display the task on the components list
          props.addTask({
            id: idCounter++,
            isDone: false,
            task: task,
          });
        }}
      >
        Add Task
      </Button>
    </div>
  );
};

export default Header;
