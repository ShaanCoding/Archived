import React from "react";
import Transaction from "./Transaction";

const HistoryComponent: React.FC<{ transaction: Transaction }> = (props) => {
  return (
    <div>
      {props.transaction.description} | {props.transaction.amount}
    </div>
  );
};

export default HistoryComponent;
