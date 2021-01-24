// This is the module that displays the cards in App.tsx

import React from "react";
import Card, { CardData } from "./Card";

//This takes in an array of cards, and the onCardDelete function (which implements the cardDelete function), and displays them
const CardList: React.FC<{
  cards: CardData[];
  onCardDelete: (cardID: number) => void;
}> = (props) => {
  return (
    <div>
      {props.cards.map((p, i) => (
        <Card
          card={p}
          key={p.id}
          onDelete={() => {
            props.onCardDelete(p.id);
          }}
        />
      ))}
    </div>
  );
};

export default CardList;
