import { ITask } from "../Interfaces";
import Task from "./Task";

const TaskList: React.FC<{
  taskList: ITask[];
  onDelete: (id: number) => void;
}> = (props) => {
  const taskMap = props.taskList.map((task: ITask) => (
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
