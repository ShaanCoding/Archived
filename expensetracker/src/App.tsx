import React, { useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import Balance from "./Components/Balance";
import IncomeExpense from "./Components/IncomeExpense";
import Transaction from "./Components/Transaction";
import AddTransaction from "./Components/AddTransaction";
import History from "./Components/History";
import ThemeWrap from "./Components/ThemeWrap";

function App() {
  //We have ahook for our transaction array

  //Saving & loading data
  let data = localStorage.getItem("TRANSACTIONS");

  let LIST;

  if (data) {
    LIST = JSON.parse(data);
  } else {
    LIST = [];
  }

  const [transactions, setTransactions] = useState<Transaction[]>(LIST);

  const getBalance = () => {
    return transactions
      .map((transaction) => transaction.amount)
      .reduce((acc, item) => (acc += item), 0);
  };

  const SaveTransaction = (transactions: Transaction[]) => {
    setTransactions(transactions);
    localStorage.setItem("TRANSACTIONS", JSON.stringify(transactions));
  };

  const onAdd = (transaction: Transaction) => {
    SaveTransaction([...transactions, transaction]);
  };

  const onDelete = (id: number) => {
    //With this we want to have all transactions but the one we want to remove
    SaveTransaction(
      transactions.filter((transaction) => {
        return transaction.id != id;
      })
    );
  };

  return (
    <ThemeWrap>
      <div className="trackerBox">
        <h1 className="header">Expense Tracker</h1>
        <Balance getBalance={getBalance} />
        <IncomeExpense transactions={transactions} />
        <History transactions={transactions} onDelete={onDelete} />
        <AddTransaction onAdd={onAdd} />
      </div>
    </ThemeWrap>
  );
}

export default App;
