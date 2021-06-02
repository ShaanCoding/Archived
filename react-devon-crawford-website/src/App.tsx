import React from "react";
import Footer from "./Components/Footer";
import FutureVentures from "./Components/FutureVentures";
import MyWork from "./Components/MyWork";
import PopularProjects from "./Components/PopularProjects";
import Splashscreen from "./Components/Splashscreen";
import StayConnected from "./Components/StayConnected";

function App() {
  return (
    <div className="App">
      <Splashscreen />
      <MyWork />
      <PopularProjects />
      <FutureVentures />
      <StayConnected />
      <Footer />
    </div>
  );
}

export default App;
