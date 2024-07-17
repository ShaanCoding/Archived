import { FaCloudShowersHeavy, FaWind, FaSun } from "react-icons/fa";

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
          <FaWind size={30} />
          {/* {Weather Icon} */}
        </>
      ) : (
        <>
          {/* {Weather icon} */}
          <FaSun size={60} />
          <p>{props.weatherDay}</p>
        </>
      )}
    </div>
  );
};

export default WeatherCard;
