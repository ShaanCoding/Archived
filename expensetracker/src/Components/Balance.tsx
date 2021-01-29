import React from "react";
import formatBalance from "./formatBalance";

const Balance: React.FC<{ balance: number }> = (props) => {
  return (
    <>
      <h4>Your Balance</h4>
      <h1>{formatBalance(props.balance)}</h1>
    </>
  );
};

export default Balance;
