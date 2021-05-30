import SideBar from "./Components/SideBar";
import Weather from "./Components/Weather";
import {
  BrowserRouter as Router,
  NavLink,
  Route,
  Switch,
} from "react-router-dom";
import Dashboard from "./Pages/Dashboard";
import QuickNote from "./Pages/QuickNote";
import ToDo from "./Pages/ToDo";

function App() {
  return (
    <Router>
      <div className="flexbox">
        <div style={{ flexGrow: 2 }}>
          <SideBar />
        </div>
        <div style={{ flexGrow: 6 }}>
          <Switch>
            <Route exact path="/">
              <Dashboard />
            </Route>
            <Route path="/quick-note">
              <QuickNote />
            </Route>
            <Route path="/to-do">
              <ToDo />
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
