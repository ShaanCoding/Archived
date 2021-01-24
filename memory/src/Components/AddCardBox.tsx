// First we start with the add box

import { Button, Container, TextField } from "@material-ui/core";
import React, { useState } from "react";
import { CardData } from "./Card";

//We want to have a main component which tracks the id of each box added, so we don't have weird issues with mistracking elements on update through V-DOM
let idCounter = 0;

const AddCardBox: React.FC<{ onAdd: (card: CardData) => void }> = (props) => {
  //React hooks with empty use state, when the setquestion is changed, the react will check, compare and find which elements to update in comparison to vdom vs physical dom
  const [question, setQuestion] = useState("");
  const [answer, setAnswer] = useState("");

  console.log(`${question} question, ${answer} answer`);

  return (
    <Container>
      {/* Question textfield 
      This takes the inital value of question which is empty and when the text is changed, it runs the setQuestion function which updates dom*/}
      <TextField
        variant="outlined"
        label="Question"
        type="text"
        value={question}
        onChange={(e) => {
          setQuestion(e.target.value);
        }}
      ></TextField>

      {/* Answer textfield */}
      <TextField
        variant="outlined"
        label="Answer"
        type="text"
        value={answer}
        onChange={(e) => {
          setAnswer(e.target.value);
        }}
      ></TextField>

      {/* Add button */}
      <Button
        variant="contained"
        color="primary"
        onClick={() => {
          // Id counter increments on every new card to all have a unique id
          // This prop passes over all this data back to the main App.tsx class through onAdd
          props.onAdd({ answer: answer, question: question, id: idCounter++ });
        }}
      ></Button>
    </Container>
  );
};

export default AddCardBox;
