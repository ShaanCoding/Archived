import React, { useState } from "react";
import Transaction from "./Transaction";

let idCounter = 0;

const AddTransaction: React.FC<{
  onAdd: (transaction: Transaction) => void;
}> = (props) => {
  const [text, setText] = useState("");
  const [amount, setAmount] = useState(0);

  return (
    <div>
      <div>
        <h4>Text</h4>
        <input
          type="text"
          value={text}
          onChange={(e) => {
            setText(e.target.value);
          }}
        />
      </div>
      <div>
        <h4>Amount</h4>
        <input
          type="text"
          value={amount}
          onChange={(e) => {
            setAmount(Number(e.target.value));
          }}
        />
      </div>
      <button
        onClick={() => {
          props.onAdd({
            amount: amount,
            id: idCounter++,
            description: text,
          });
        }}
      >
        Add Transaction
      </button>
    </div>
  );
};

export default AddTransaction;
