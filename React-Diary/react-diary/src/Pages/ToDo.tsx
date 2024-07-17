import React, { useEffect, useState } from "react";
import { ITask } from "../Components/Interfaces";
import Header from "../Components/To Do Component/Header";
import TaskList from "../Components/To Do Component/TaskList";
import {
  addToDo,
  deleteToDo,
  fetchToDos,
  toggleToDo,
} from "../Components/TodayRecentQuickNote";

const ToDo: React.FC = (props) => {
  // Tracks all tasks
  const [tasks, setTasks] = useState<ITask[]>([]);

  useEffect(() => {
    const getToDo = async () => {
      const getToDoFromServer = await fetchToDos();
      setTasks(getToDoFromServer);
    };

    getToDo();
  }, []);

  return (
    <div className="to-do">
      <Header
        addTask={(task) => {
          addToDo(tasks, setTasks, task);
        }}
      />
      <TaskList
        taskList={tasks}
        onDelete={(id: number) => {
          deleteToDo(tasks, setTasks, id);
        }}
        onTaskClick={(id: number) => {
          toggleToDo(tasks, setTasks, id);
        }}
      />
    </div>
  );
};

export default ToDo;
