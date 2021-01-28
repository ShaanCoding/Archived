import React from "react";
import { convertTypeAcquisitionFromJson } from "typescript";
import Task from "./Task";
import TaskData from "./TaskData";

const TaskList: React.FC<{
  tasksList: TaskData[];
  onDelete: (id: number) => void;
}> = (props) => {
  // Remaps task map to task list
  const taskMap = props.tasksList.map((task) => (
    <Task
      task={task}
      key={task.id}
      onDelete={() => {
        props.onDelete(task.id);
      }}
    />
  ));

  return <div>{taskMap}</div>;
};

export default TaskList;
