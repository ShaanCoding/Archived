// This is the module that displays the cards in App.tsx

import { Grid } from "@material-ui/core";
import React from "react";
import Card, { CardData } from "./Card";

import { css, jsx } from "@emotion/react";
import styled from "@emotion/styled";

const StyledDiv = styled.div`
  min-width: 150px;
`;

//This takes in an array of cards, and the onCardDelete function (which implements the cardDelete function), and displays them
const CardList: React.FC<{
  cards: CardData[];
  onCardDelete: (cardID: number) => void;
}> = (props) => {
  return (
    <Grid
      container
      spacing={4}
      direction="row"
      justify="flex-start"
      alignItems="flex-start"
    >
      {props.cards.map((p, i) => (
        <Grid item key={p.id}>
          <StyledDiv>
            <Card
              card={p}
              key={p.id}
              onDelete={() => {
                props.onCardDelete(p.id);
              }}
            />
          </StyledDiv>
        </Grid>
      ))}
    </Grid>
  );
};

export default CardList;
