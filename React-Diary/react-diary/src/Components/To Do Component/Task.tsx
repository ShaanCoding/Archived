import { Button, Checkbox } from "@material-ui/core";
import { ITask } from "../Interfaces";

const Task: React.FC<{
  task: ITask;
  onDelete: () => void;
  onTaskClick: (id: number) => void;
}> = (props) => {
  return (
    <div>
      <Checkbox
        checked={props.task.isDone}
        onClick={() => props.onTaskClick(props.task.id)}
      />
      {props.task.taskName}
      <Button
        variant="contained"
        color="secondary"
        onClick={() => props.onDelete()}
      >
        Delete
      </Button>
    </div>
  );
};

export default Task;
