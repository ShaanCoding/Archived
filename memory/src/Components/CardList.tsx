// This is the module that displays the cards in App.tsx

import { Grid } from "@material-ui/core";
import React from "react";
import Card, { CardData } from "./Card";

//This takes in an array of cards, and the onCardDelete function (which implements the cardDelete function), and displays them
const CardList: React.FC<{
  cards: CardData[];
  onCardDelete: (cardID: number) => void;
}> = (props) => {
  return (
    <Grid
      container
      spacing={10}
      direction="row"
      justify="flex-start"
      alignItems="flex-start"
    >
      {props.cards.map((p, i) => (
        <Grid item key={p.id}>
          <Card
            card={p}
            key={p.id}
            onDelete={() => {
              props.onCardDelete(p.id);
            }}
          />
        </Grid>
      ))}
    </Grid>
  );
};

export default CardList;
