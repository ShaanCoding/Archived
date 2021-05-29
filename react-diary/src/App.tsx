import SideBar from "./Components/SideBar";
import Weather from "./Components/Weather";
import {
  BrowserRouter as Router,
  NavLink,
  Route,
  Switch,
} from "react-router-dom";
import Dashboard from "./Components/Dashboard";

function App() {
  return (
    <Router>
      <div className="flexbox">
        <div style={{ flexGrow: 2 }}>
          <SideBar />
        </div>
        <div style={{ flexGrow: 6 }}>
          <Switch>
            <Route path="/">
              <Dashboard />
            </Route>
          </Switch>
        </div>
        <div style={{ flexGrow: 1 }}>
          <Weather />
        </div>
      </div>
    </Router>
  );
}

export default App;
