import { Button, Checkbox, Radio, Switch } from "@material-ui/core";
import React, { useState } from "react";
import { setSyntheticLeadingComments } from "typescript";
import TaskData from "./TaskData";

import DeleteOutlineOutlinedIcon from "@material-ui/icons/DeleteOutlineOutlined";
import { css } from "@emotion/react";
import styled from "@emotion/styled";

const Container = styled.div`
  display: flex;
  flex-wrap: nowrap;
`;

const Task: React.FC<{ task: TaskData; onDelete: () => void }> = (props) => {
  //Make prop for done or undone
  const [done, setDone] = useState(false);

  return (
    <Container className="todo-row">
      <Switch
        checked={done}
        onChange={() => {
          setDone(!done);
        }}
      />

      {/* If it is done we display the striked through one */}

      {!done ? (
        <h1>{props.task.task}</h1>
      ) : (
        <h1>
          <s>{props.task.task}</s>
        </h1>
      )}

      {/* Delete button */}
      <div
        onClick={() => {
          props.onDelete();
        }}
      >
        <DeleteOutlineOutlinedIcon />
      </div>
    </Container>
  );
};

export default Task;
