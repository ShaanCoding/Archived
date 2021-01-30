import { Button, Input, TextField } from "@material-ui/core";
import React, { useState } from "react";
import Transaction from "./Transaction";

let data = localStorage.getItem("ID");
let ID = data ? JSON.parse(data) : 0;

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
        <h3>Text</h3>
        <TextField
          variant="outlined"
          label="Add a description"
          color="secondary"
          type="text"
          value={text}
          onChange={(e) => {
            setText(e.target.value);
          }}
        />
      </div>
      <div>
        <h3>Amount</h3>
        <TextField
          variant="outlined"
          label="Add an amount"
          color="secondary"
          type="text"
          value={amount}
          onChange={(e) => {
            setAmount(e.target.value);
          }}
        />
      </div>
      <br />
      <Button
        variant="contained"
        color="primary"
        type="submit"
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
      </Button>

      {error ? <h4 className="error">Illegal Amount Entered</h4> : ""}
    </div>
  );
};

export default AddTransaction;
