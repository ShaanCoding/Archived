import SideBar from "./Components/SideBar";
import Weather from "./Components/Weather";
import { NavLink, Route, Switch, useParams } from "react-router-dom";
import Dashboard from "./Pages/Dashboard";
import QuickNote from "./Pages/QuickNote";
import ToDo from "./Pages/ToDo";
import Notes from "./Pages/Notes";
import RoutedNote from "./Pages/RoutedNote";
import FileNotFound from "./Pages/FileNotFound";
import NewNote from "./Pages/NewNote";

function App() {
  const { id } = useParams<{ id: string }>();

  return (
    <div className="flexbox">
      <div style={{ flexGrow: 2 }}>
        <SideBar />
      </div>
      <div style={{ flexGrow: 6 }}>
        <Switch>
          <Route exact path="/" component={Dashboard} />
          <Route path="/quick-note" component={QuickNote} />
          <Route path="/to-do" component={ToDo} />
          <Route exact path="/notes" component={Notes} />
          <Route path={`/notes/:id`} component={RoutedNote} />
          <Route exact path="/new-note">
            <NewNote />
          </Route>
          <Route>
            <FileNotFound />
          </Route>
        </Switch>
      </div>
      <div style={{ flexGrow: 1 }}>
        <Weather />
      </div>
    </div>
  );
}

export default App;
