import { Button, Grid } from "@material-ui/core";
import React, { useState } from "react";

// Interface for the datatype of cards
export interface CardData {
  question: string;
  answer: string;
  id: number;
}

const Card: React.FC<{ card: CardData; onDelete: () => void }> = (props) => {
  // Hook, setting the usestate to false (being hidden till updated)
  const [showing, setShowing] = useState(false);

  return (
    //The div should have a function of where it updates the following function on div click
    <Grid
      container
      direction="column"
      justify="center"
      alignItems="center"
      onClick={() => {
        setShowing(!showing);
      }}
    >
      <h3>Question:</h3>
      {props.card.question}

      {/* If it is allowed to be shown we show it otherwise display null (tenary) */}
      {!showing ? null : (
        <>
          <h3>Answer:</h3>
          {props.card.answer}
          <br />
          <Button
            variant="outlined"
            color="primary"
            onClick={() => {
              // Delete function deletes the card when button is pressed
              props.onDelete();
            }}
          >
            Delete Card
          </Button>
        </>
      )}
    </Grid>
  );
};

export default Card;
