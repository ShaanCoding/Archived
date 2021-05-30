import { useState } from "react";
import { ITask } from "../Interfaces";
import TaskList from "./TaskList";

const Header: React.FC<{ addTask: (task: any) => void }> = (props) => {
  const [task, setTask] = useState<string>("");

  return (
    <div>
      <input
        type="textfield"
        value={task}
        onChange={(e) => {
          setTask(e.target.value);
        }}
      />

      <button
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
      </button>
    </div>
  );
};

export default Header;
