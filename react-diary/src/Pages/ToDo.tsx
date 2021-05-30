import React, { useState } from "react";
import { ITask } from "../Components/Interfaces";
import Header from "../Components/To Do Component/Header";
import TaskList from "../Components/To Do Component/TaskList";

const ToDo: React.FC = (props) => {
  // Tracks all tasks
  const [tasks, setTasks] = useState<ITask[]>([]);

  return (
    <div>
      <Header
        addTask={(task) => {
          setTasks([...tasks, task]);
        }}
      />
      <TaskList
        taskList={tasks}
        onDelete={(id: number) => {
          setTasks(tasks.filter((task: ITask) => task.id !== id));
        }}
      />
    </div>
  );
};

export default ToDo;
