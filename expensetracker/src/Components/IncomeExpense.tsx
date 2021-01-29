import React from "react";
import formatBalance from "./formatBalance";
import Transaction from "./Transaction";

const IncomeExpense: React.FC<{ transactions: Transaction[] }> = (props) => {
  // Get amount and then filter for income and expenses
  const income = props.transactions
    .map((transaction) => transaction.amount)
    .filter((item) => item > 0)
    .reduce((acc, item) => (acc += item), 0);
  const expenses =
    props.transactions
      .map((transaction) => transaction.amount)
      .filter((item) => item < 0)
      .reduce((acc, item) => (acc += item), 0) * -1;

  return (
    <div>
      <div>
        <h4>Income</h4>
        <p>{formatBalance(income)}</p>
      </div>
      <div>
        <h4>Expense</h4>
        <p>{formatBalance(expenses)}</p>
      </div>
    </div>
  );
};

export default IncomeExpense;
