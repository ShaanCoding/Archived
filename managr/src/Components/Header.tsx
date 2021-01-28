import React, { useState } from "react";
import { Box, Button, Input, TextField } from "@material-ui/core";
import TaskData from "./TaskData";

let idCounter = 0;

const Header: React.FC<{ addTask: (task: TaskData) => void }> = (props) => {
  const [task, setTask] = useState("");

  return (
    <Box m={2} pt={3}>
      <TextField
        variant="outlined"
        label="Add a task"
        type="text"
        value={task}
        onChange={(e) => {
          setTask(e.target.value);
        }}
      />
      <br />
      <br />
      <Button
        variant="contained"
        color="primary"
        onClick={() => {
          //We need a callback function to the main class and then display the task on the components list
          if (task) {
            props.addTask({
              id: idCounter++,
              isDone: false,
              task: task,
            });
          }
        }}
      >
        Add Task
      </Button>
    </Box>
  );
};

export default Header;
