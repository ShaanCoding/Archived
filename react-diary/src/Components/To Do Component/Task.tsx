import { ITask } from "../Interfaces";

const Task: React.FC<{
  task: ITask;
  onDelete: () => void;
  onTaskClick: (id: number) => void;
}> = (props) => {
  return (
    <div className="toDoElement">
      <input
        type="checkbox"
        checked={props.task.isDone}
        onClick={() => props.onTaskClick(props.task.id)}
      />
      {props.task.taskName}
      <button onClick={() => props.onDelete()}>Delete</button>
    </div>
  );
};

export default Task;
