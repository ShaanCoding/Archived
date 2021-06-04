import InfoBox from "./Components/InfoBox";
import Partners from "./Components/Partners";
import Splashscreen from "./Components/Splashscreen";

import infoboxImg from "./images/infobox/infobox-1.PNG";

function App() {
  return (
    <div className="App">
      <Splashscreen />
      <Partners />
      <InfoBox
        subHeading="POTENTIAL OF RADAR"
        heading="Limitations of Traditional Radar"
        paragraph="For decades, commercial radars have suffered from poor angular
        resolution and limited FOVs because traditional designs require more
        antennas for higher resolution. Additional atennas increase cost, size
        and power expontially, limited what is commercially feasible."
        buttonName="Learn more"
        buttonURL=""
        image={infoboxImg}
      />
      <InfoBox
        subHeading="POTENTIAL OF RADAR"
        heading="Limitations of Traditional Radar"
        paragraph="For decades, commercial radars have suffered from poor angular
        resolution and limited FOVs because traditional designs require more
        antennas for higher resolution. Additional atennas increase cost, size
        and power expontially, limited what is commercially feasible."
        buttonName="Learn more"
        buttonURL=""
        image={infoboxImg}
        isReverse={true}
      />
    </div>
  );
}

export default App;
