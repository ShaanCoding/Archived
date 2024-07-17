public class ConsolidatedWeather
{
    //Variable
    private long id;
    private String weather_state_name;
    private String weather_state_abbr;
    private String wind_direction_compass;
    private String created;
    private String applicable_date;
    private double min_temp;
    private double max_temp;
    private double the_temp;
    private double wind_speed;
    private double wind_direction;
    private double air_pressure;
    private  double humidity;
    private double visibility;
    private double predictability;

    //Getter functions
    public long getID()
    {
        return id;
    }

    public String getWeatherStateName()
    {
        return weather_state_name;
    }

    public String getWeatherStateAbbr()
    {
        return weather_state_abbr;
    }

    public String getWindDirectionCompass()
    {
        return wind_direction_compass;
    }

    public String getCreated()
    {
        return created;
    }

    public String getApplicableDate()
    {
        return applicable_date;
    }

    public double getMinTemp()
    {
        return min_temp;
    }

    public double getMaxTemp()
    {
        return max_temp;
    }

    public double getTheTemp()
    {
        return the_temp;
    }

    public double getWindSpeed()
    {
        return wind_speed;
    }

    public double getWindDirection()
    {
        return wind_direction;
    }

    public double getAirPressure()
    {
        return air_pressure;
    }

    public double getHumidity()
    {
        return humidity;
    }

    public double getVisibility()
    {
        return visibility;
    }

    public double getPredictability()
    {
        return predictability;
    }
}
