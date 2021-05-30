import { ITask } from "../Interfaces";

const Task: React.FC<{ task: ITask; onDelete: () => void }> = (props) => {
  return (
    <div>
      <input type="checkbox" checked={props.task.isDone} />
      <p>{props.task.taskName}</p>
      <button onClick={() => props.onDelete()}>Delete</button>
    </div>
  );
};

export default Task;
