import React from "react";
import Transaction from "./Transaction";

const HistoryComponent: React.FC<{
  transaction: Transaction;
  onDelete: (id: number) => void;
}> = (props) => {
  return (
    <div onDoubleClick={() => props.onDelete(props.transaction.id)}>
      {props.transaction.description} | {props.transaction.amount}
    </div>
  );
};

export default HistoryComponent;
