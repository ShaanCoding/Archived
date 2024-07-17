import React, { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import Header from "./Components/Header";
import TaskData from "./Components/TaskData";
import TaskList from "./Components/TaskList";
import ThemeWrap from "./Components/ThemeWrap";

function App() {
  //Make a hook for task
  const [tasks, setTask] = useState<TaskData[]>([]);

  return (
    <ThemeWrap>
      <div className="todo-app">
        <h1 className="header">Managr</h1>
        <h2>A simplistic to-do list created in React</h2>
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
    </ThemeWrap>
  );
}

export default App;
