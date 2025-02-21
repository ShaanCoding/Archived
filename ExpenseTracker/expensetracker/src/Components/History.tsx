import React from "react";
import HistoryComponent from "./HistoryComponent";
import Transaction from "./Transaction";
import "../App.css";

const History: React.FC<{
  transactions: Transaction[];
  onDelete: (id: number) => void;
}> = (props) => {
  const onDelete = (id: number) => {
    props.onDelete(id);
  };

  const arrayMap = props.transactions.map((transaction) => {
    return (
      <HistoryComponent
        transaction={transaction}
        key={transaction.id}
        onDelete={onDelete}
      />
    );
  });
  return <ul className="list">{arrayMap}</ul>;
};

export default History;
