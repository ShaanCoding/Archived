import { INote } from "../Components/Interfaces";

const Note: React.FC<{ noteContent?: INote }> = (props) => {
  return (
    <div>
      <h1>{props.noteContent?.noteName}</h1>
    </div>
  );
};

export default Note;
