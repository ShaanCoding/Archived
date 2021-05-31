import SideBar from "./Components/SideBar";
import Weather from "./Components/Weather";
import { NavLink, Route, Switch, useParams } from "react-router-dom";
import Dashboard from "./Pages/Dashboard";
import QuickNote from "./Pages/QuickNote";
import ToDo from "./Pages/ToDo";
import Notes from "./Pages/Notes";
import RoutedNote from "./Pages/RoutedNote";

function App() {
  const { id } = useParams<{ id: string }>();

  return (
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
          <Route exact path="/notes" component={Notes} />
          <Route path={`/notes/:id`} component={RoutedNote} />
        </Switch>
      </div>
      <div style={{ flexGrow: 1 }}>
        <Weather />
      </div>
    </div>
  );
}

export default App;
