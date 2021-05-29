const WeatherCard: React.FC<{
  isGrey: boolean;
  isUpcoming: boolean;
  weatherIcon: string;
  weatherDay: string;
}> = (props) => {
  return (
    <div className={`${props.isGrey && "grey"}`}>
      {props.isUpcoming ? (
        <>
          <h1>UPCOMING</h1>
          <p>{props.weatherDay}</p>
          {/* {Weather Icon} */}
        </>
      ) : (
        <>
          {/* {Weather icon} */}
          <p>{props.weatherDay}</p>
        </>
      )}
    </div>
  );
};

export default WeatherCard;
