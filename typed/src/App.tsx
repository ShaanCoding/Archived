import React, { Component, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import { getByText } from "@testing-library/react";
import Preview from "./Components/Preview";
import Speed from "./Components/Speed";
import getText from "./Components/GetText";
import { Box, Button, Input } from "@material-ui/core";
import ThemeWrap from "./Components/ThemeWrap";

const initialState = {
  text: getText(),
  userInput: "",
  symbols: 0,
  sec: 0,
  started: false,
  finished: false,
};

interface State {
  text: string;
  userInput: string;
  symbols: number;
  sec: number;
  started: boolean;
  finished: boolean;
}

class App extends Component<{}, State> {
  private interval: any;

  constructor(props: any) {
    super(props);

    this.state = initialState;
  }

  // On reset, we reset the state to the defaults
  onRestart = () => {
    this.setState(initialState);
  };

  //When a user enters a new keystroke, we make a timer, check if it's finished, update userinput and update the symbols
  onUserInputChange = (e: any) => {
    const v = e.target.value;
    this.setTimer();
    this.onFinish(v);
    this.setState({
      userInput: v,
      symbols: this.countCorrectSymbols(v),
    });
  };

  //When it's done we stop measuring our interval
  onFinish(userInput: string) {
    if (userInput === this.state.text) {
      clearInterval(this.interval);
      this.setState({
        finished: true,
      });
    }
  }

  // This santizes the userinput removing spaces and checks if its correct
  countCorrectSymbols(userInput: string) {
    const text = this.state.text.replace(" ", "");
    return userInput
      .replace(" ", "")
      .split("")
      .filter((s, i) => s === text[i]).length;
  }

  setTimer() {
    if (!this.state.started) {
      this.setState({ started: true });
      this.interval = setInterval(() => {
        this.setState((prevProps) => {
          return { sec: prevProps.sec + 1 };
        });
      }, 1000);
    }
  }

  render() {
    return (
      <ThemeWrap>
        <div className="type">
          <Box m={2} pt={4}>
            <h1 className="header">TypeD</h1>
            <Preview text={this.state.text} userInput={this.state.userInput} />
            <Input
              value={this.state.userInput}
              onChange={this.onUserInputChange}
              placeholder="Start typing..."
              readOnly={this.state.finished}
            />
            <Speed sec={this.state.sec} symbols={this.state.symbols} />
            <div>
              <Button
                variant="contained"
                color="primary"
                onClick={this.onRestart}
              >
                Restart
              </Button>
            </div>
          </Box>
        </div>
      </ThemeWrap>
    );
  }
}

export default App;
