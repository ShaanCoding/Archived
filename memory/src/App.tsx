import React from "react";
import logo from "./logo.svg";
import "./App.css";
import ThemeWrap from "./Components/ThemeWrap";

function App() {
  return (
    <ThemeWrap>
      <AddCardBox />

      <CardList />
    </ThemeWrap>
  );
}

export default App;
