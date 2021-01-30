import React from "react";
import AddTransaction from "./AddTransaction";
import Transaction from "./Transaction";
import "../App.css";

const HistoryComponent: React.FC<{
  transaction: Transaction;
  onDelete: (id: number) => void;
}> = (props) => {
  return (
    <li
      className={props.transaction.amount < 0 ? "minus" : "plus"}
      onDoubleClick={() => props.onDelete(props.transaction.id)}
    >
      {props.transaction.description}
      <span>{props.transaction.amount}</span>
    </li>
  );
};

export default HistoryComponent;
