const InfoBox: React.FC<{
  subHeading: string;
  heading: string;
  paragraph: string;
  buttonName: string;
  buttonURL: string;
  image: string;
  isReverse?: boolean;
}> = (props) => {
  return (
    <div
      className="infobox box"
      style={{ flexDirection: !props.isReverse ? "row" : "row-reverse" }}
    >
      <div style={{ flex: 2 }}>
        <h2>{props.subHeading}</h2>
        <h1>{props.heading}</h1>
        <p>{props.paragraph}</p>
        <a href={props.buttonURL}>
          <button>{props.buttonName}</button>
        </a>
      </div>

      <div style={{ flex: 1 }}>
        <img src={props.image} />
      </div>
    </div>
  );
};

export default InfoBox;
