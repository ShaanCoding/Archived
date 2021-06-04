import { useState } from "react";

const Carousel: React.FC<{}> = (props) => {
  interface ICarousel {
    blogProvider: string;
    title: string;
    paragraph: string;
    readMoreURL: string;
  }
  let [index, setIndex] = useState<number>(0);

  // Normally you'd get this off a REST API

  const carouselInfo: ICarousel[] = [
    {
      blogProvider: "Techcrunch",
      title: "Oculii Looks to Supercharge Radar for Autonomy with $55M Round B",
      paragraph:
        "Oculii, the leading provider of advanced AI software for radar perception, today annouced a $55 million Series B funding round to scale and deliver on the insatiable demands of Tier-Ts and OEMs globally",
      readMoreURL: "",
    },
    {
      blogProvider: "Shaan Khan",
      title: "Shaan Khan looks to create good webdevelopment portfolio",
      paragraph:
        "Oculii, the leading provider of advanced AI software for radar perception, today annouced a $55 million Series B funding round to scale and deliver on the insatiable demands of Tier-Ts and OEMs globally",
      readMoreURL: "",
    },
  ];

  const addIndex = (number: number) => {
    if (number + index >= 0 && number + index < carouselInfo.length) {
      setIndex(index + number);
    }
  };

  return (
    <div className="box">
      <div className="carousel">
        <button onClick={() => addIndex(1)}>Left</button>
        <div>
          <h2>{carouselInfo[index].blogProvider}</h2>
          <h1>{carouselInfo[index].title}</h1>
          <p>{carouselInfo[index].paragraph}</p>
          <a href={carouselInfo[index].readMoreURL}>Read more</a>
        </div>
        <button onClick={() => addIndex(-1)}>Right</button>
      </div>
    </div>
  );
};

export default Carousel;
