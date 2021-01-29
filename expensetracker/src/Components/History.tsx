import React from "react";
import HistoryComponent from "./HistoryComponent";
import Transaction from "./Transaction";

const History: React.FC<{ transactions: Transaction[] }> = (props) => {
  const arrayMap = props.transactions.map((transaction) => {
    return <HistoryComponent transaction={transaction} key={transaction.id} />;
  });
  return <div>{arrayMap}</div>;
};

export default History;
