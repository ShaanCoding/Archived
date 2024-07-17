import WeatherCard from "./WeatherCard";

const Weather: React.FC = () => {
  return (
    <div className="weather-card">
      <WeatherCard
        isGrey={false}
        isUpcoming={false}
        weatherIcon=""
        weatherDay="THURSDAY, OCTOBER 29"
      />
      <WeatherCard
        isGrey={true}
        isUpcoming={true}
        weatherIcon=""
        weatherDay="THURSDAY, OCTOBER 29"
      />
      <WeatherCard
        isGrey={true}
        isUpcoming={true}
        weatherIcon=""
        weatherDay="THURSDAY, OCTOBER 29"
      />
    </div>
  );
};

export default Weather;
