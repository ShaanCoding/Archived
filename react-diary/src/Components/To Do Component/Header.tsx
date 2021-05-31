import { Button, TextField } from "@material-ui/core";
import React, { useState } from "react";
import { ITask } from "../Interfaces";
import TaskList from "./TaskList";

const Header: React.FC<{ addTask: (task: any) => void }> = (props) => {
  const [task, setTask] = useState<string>("");

  return (
    <div>
      <h1>TO DO</h1>
      <TextField
        value={task}
        onChange={(e) => {
          setTask(e.target.value);
        }}
      />

      <Button
        variant="contained"
        color="secondary"
        onClick={() => {
          if (task) {
            props.addTask({
              isDone: false,
              taskName: task,
            });
          }
        }}
      >
        Add Task
      </Button>
    </div>
  );
};

export default Header;
