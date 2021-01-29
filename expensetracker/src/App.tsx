import React, { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import Balance from "./Components/Balance";
import IncomeExpense from "./Components/IncomeExpense";
import Transaction from "./Components/Transaction";
import AddTransaction from "./Components/AddTransaction";
import History from "./Components/History";

function App() {
  //We have ahook for our transaction array
  const [transactions, setTransactions] = useState<Transaction[]>([]);

  const getBalance = () => {
    return transactions
      .map((transaction) => transaction.amount)
      .reduce((acc, item) => (acc += item), 0);
  };

  const onAdd = (transaction: Transaction) => {
    setTransactions([...transactions, transaction]);
  };

  return (
    <div className="App">
      <h1>Expense Tracker</h1>
      <Balance balance={getBalance()} />
      <IncomeExpense transactions={transactions} />
      <History transactions={transactions} />
      <AddTransaction onAdd={onAdd} />
    </div>
  );
}

export default App;
