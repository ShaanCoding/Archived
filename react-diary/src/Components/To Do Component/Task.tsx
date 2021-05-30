import { ITask } from "../Interfaces";

const Task: React.FC<{
  task: ITask;
  onDelete: () => void;
  onTaskClick: (id: number) => void;
}> = (props) => {
  return (
    <div>
      <input
        type="checkbox"
        checked={props.task.isDone}
        onClick={() => props.onTaskClick(props.task.id)}
      />
      <p>{props.task.taskName}</p>
      <button onClick={() => props.onDelete()}>Delete</button>
    </div>
  );
};

export default Task;
