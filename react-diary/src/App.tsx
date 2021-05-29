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
        <div>
          <SideBar />
        </div>
        <div>
          <Switch>
            <Route path="/">
              <Dashboard />
            </Route>
          </Switch>
        </div>
        <div>
          <Weather />
        </div>
      </div>
    </Router>
  );
}

export default App;
