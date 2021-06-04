import Carousel from "./Components/Carousel";
import InfoBox from "./Components/InfoBox";
import LearnMore from "./Components/LearnMore";
import Partners from "./Components/Partners";
import Product from "./Components/Product";
import Products from "./Components/Products";
import Splashscreen from "./Components/Splashscreen";

import infoboxImg from "./images/infobox/infobox-1.PNG";

function App() {
  const productProperties: string[] = [
    "200M range",
    "120° Azimuth field of view",
    "30° Elevation field of view",
    "2.5 watts power consumption",
  ];

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

      <Carousel />

      <Products title="Imaging Radar Product">
        <Product
          productTitle="Falcon"
          productDescription="Single Chip 4D Radar for ADAS Corner Radar Applications and Robotic
        Perception"
          productPerformance="20X"
          productPerformanceDescription="Performance compared to the best selling sensor in its class"
          productAzimuth="2.0°"
          productElevation="5.0°"
          productPropertiesList={productProperties}
        />
        <Product
          productTitle="Falcon"
          productDescription="Single Chip 4D Radar for ADAS Corner Radar Applications and Robotic
        Perception"
          productPerformance="20X"
          productPerformanceDescription="Performance compared to the best selling sensor in its class"
          productAzimuth="2.0°"
          productElevation="5.0°"
          productPropertiesList={productProperties}
        />
      </Products>
      <LearnMore />
    </div>
  );
}

export default App;
