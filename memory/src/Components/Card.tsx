import { Button } from "@material-ui/core";
import { useState } from "react";

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
    <div
      onClick={() => {
        setShowing(!showing);
      }}
    >
      <p>Question:</p>
      {props.card.question}

      {/* If it is allowed to be shown we show it otherwise display null (tenary) */}
      {!showing ? null : (
        <>
          <p>Answer:</p>
          {props.card.answer}

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
    </div>
  );
};

export default Card;
