import React, { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import Header from "./Components/Header";
import TaskData from "./Components/TaskData";
import TaskList from "./Components/TaskList";

function App() {
  //Make a hook for task
  const [tasks, setTask] = useState<TaskData[]>([]);

  return (
    <div>
      <Header
        addTask={(task) => {
          setTask([...tasks, task]);
        }}
      />

      {/* We need a delete method to remove */}
      <TaskList
        tasksList={tasks}
        onDelete={(id) => {
          setTask(tasks.filter((t) => t.id != id));
        }}
      />
    </div>
  );
}

export default App;
