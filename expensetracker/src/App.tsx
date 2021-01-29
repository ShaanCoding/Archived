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

  const onDelete = (id: number) => {
    //With this we want to have all transactions but the one we want to remove
    setTransactions(
      transactions.filter((transaction) => {
        return transaction.id != id;
      })
    );
  };

  return (
    <div className="App">
      <h1>Expense Tracker</h1>
      <Balance getBalance={getBalance} />
      <IncomeExpense transactions={transactions} />
      <History transactions={transactions} onDelete={onDelete} />
      <AddTransaction onAdd={onAdd} />
    </div>
  );
}

export default App;
