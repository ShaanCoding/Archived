import React from "react";
import formatBalance from "./formatBalance";

const Balance: React.FC<{ getBalance: () => number }> = (props) => {
  return (
    <>
      <h4>Your Balance</h4>
      <h1>{formatBalance(props.getBalance())}</h1>
    </>
  );
};

export default Balance;
