import React, { useState } from "react";
import Transaction from "./Transaction";

let data = localStorage.getItem("ID");

let ID;

if (data) {
  ID = JSON.parse(data);
} else {
  ID = 0;
}

let idCounter = ID;

const AddTransaction: React.FC<{
  onAdd: (transaction: Transaction) => void;
}> = (props) => {
  const [text, setText] = useState("");
  const [amount, setAmount] = useState("");
  const [error, setError] = useState(false);

  const isLegal = (amount: string) => {
    return !isNaN(Number(amount));
  };

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
            setAmount(e.target.value);
          }}
        />
      </div>
      <button
        onClick={() => {
          if (isLegal(amount)) {
            setError(false);
            props.onAdd({
              amount: Number(amount),
              id: idCounter++,
              description: text,
            });
            localStorage.setItem("ID", idCounter);
          } else {
            setError(true);
          }
        }}
      >
        Add Transaction
      </button>

      {error ? <h4>Illegal Amount Entered</h4> : ""}
    </div>
  );
};

export default AddTransaction;
