import com.google.gson.Gson;
import com.google.gson.JsonElement;
import com.google.gson.JsonObject;
import com.google.gson.JsonParser;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.net.URL;
import java.net.URLConnection;
import java.text.DateFormat;
import java.text.DecimalFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.Scanner;

import javax.swing.*;
import java.awt.*;
import java.awt.event.*;

public class Program implements ActionListener
{
    private static final DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd");
    private static final DecimalFormat decimalFormat = new DecimalFormat("#.##");
    private static String location = "";
    private static int dayCycle = 0;
    private static String[][] sevenDayData = new String[7][8];

    private JLabel dayLabel = new JLabel();
    private JLabel locationLabel = new JLabel();

    private JLabel weatherStateLabel = new JLabel();
    private JLabel currentTempLabel = new JLabel();
    private JLabel minTempLabel = new JLabel();
    private JLabel maxTempLabel = new JLabel();
    private JLabel windSpeedLabel = new JLabel();
    private JLabel visibilityLabel = new JLabel();
    private JLabel airPressureLabel = new JLabel();
    private JLabel humidityLabel = new JLabel();

    JTextField locationTextBox = new JTextField();
    JButton confirmLocationButton = new JButton("Confirm");
    JButton cycleDayButton = new JButton("Next Day");

    private JFrame frame = new JFrame();

    public Program()
    {
        // the panel with the button and text
        JPanel panel = new JPanel();
        panel.setBorder(BorderFactory.createEmptyBorder(30, 30, 10, 30));
        panel.setLayout(new GridLayout(0, 1));

        //Gives day 1 info to menu
        dayLabel.setText("Day: 1");
        locationLabel.setText("Location:");
        weatherStateLabel.setText("Weather: ");
        currentTempLabel.setText("Current Temp: ");
        minTempLabel.setText("Min Temp: ");
        maxTempLabel.setText("Max Temp: ");
        windSpeedLabel.setText("Wind Speed: ");
        visibilityLabel.setText("Visibility: ");
        airPressureLabel.setText("Air Pressure: ");
        humidityLabel.setText("Humidity: ");

        // clickable button
        confirmLocationButton.addActionListener(this);
        cycleDayButton.addActionListener(this);

        //Adds stuff to panel
        panel.add(locationTextBox);
        panel.add(confirmLocationButton);
        panel.add(dayLabel);
        panel.add(locationLabel);
        panel.add(weatherStateLabel);
        panel.add(currentTempLabel);
        panel.add(minTempLabel);
        panel.add(maxTempLabel);
        panel.add(windSpeedLabel);
        panel.add(visibilityLabel);
        panel.add(airPressureLabel);
        panel.add(humidityLabel);
        panel.add(cycleDayButton);


        // set up the frame and display it
        frame.add(panel, BorderLayout.CENTER);
        frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        frame.setTitle("Cloudly");
        frame.pack();
        frame.setVisible(true);
    }

    public static void main(String[] args)
    {
        new Program();
    }

    // process the button clicks
    public void actionPerformed(ActionEvent e)
    {
        if(e.getSource() == cycleDayButton)
        {
            //Put button actions in
            if(dayCycle < 6)
            {
                dayCycle++;
            }
            else
            {
                dayCycle = 0;
            }

            updateLabels();
        }
        else if(e.getSource() == confirmLocationButton)
        {
            location = locationTextBox.getText();
            locationTextBox.setText("");
            sevenDayData = sevenDaysWeather();
        }
    }

    public void updateLabels()
    {
        dayLabel.setText("Day: " + (dayCycle + 1));
        locationLabel.setText("Location: " + location);
        weatherStateLabel.setText("Weather: " + sevenDayData[dayCycle][0]);
        currentTempLabel.setText("Current Temp: " + sevenDayData[dayCycle][1]);
        minTempLabel.setText("Min Temp: " + sevenDayData[dayCycle][2]);
        maxTempLabel.setText("Max Temp: " + sevenDayData[dayCycle][3]);
        windSpeedLabel.setText("Wind Speed: " + sevenDayData[dayCycle][4]);
        visibilityLabel.setText("Visibility: " + sevenDayData[dayCycle][5]);
        airPressureLabel.setText("Air Pressure: " + sevenDayData[dayCycle][6]);
        humidityLabel.setText("Humidity: " + sevenDayData[dayCycle][7]);
    }

    public static String[][] sevenDaysWeather()
    {
        //Day then data
        String[][] returnWeather = new String[7][8];
        long woeID;
        try
        {
            woeID = getWoeID();

            for(int i = 0; i < 7; i++)
            {
                returnWeather[i] = getWeather(woeID, getAddedDate(i));
            }
            return returnWeather;
        }
        catch(Exception ex)
        {
            return null;
        }

    }

    private static long getWoeID()
    {
        //add forward slash yyyy/mm/dd to WOeID to get next day
        try
        {
            URL findWOEIDURL = new URL(String.format("https://www.metaweather.com/api/location/search/?query=%s", location));
            InputStreamReader reader = new InputStreamReader(findWOEIDURL.openStream());
            WoeIDJson[] data = new Gson().fromJson(reader, WoeIDJson[].class);

            return data[0].getWoeID();
        }
        catch(Exception ex)
        {
            System.out.println(ex.toString());
            return 0;
        }
    }

    private static String getAddedDate(int i)
    {
        Date currentDate = new Date();
        Calendar calendar = Calendar.getInstance();
        calendar.setTime(currentDate);
        calendar.add(Calendar.DATE, i);
        Date addedDate = calendar.getTime();
        return dateFormat.format(addedDate);
    }

    private static String[] getWeather(long woeID, String dateString)
    {
        String[] returnString = new String[8];
        try
        {
            //add forward slash yyyy/mm/dd to WOeID to get next day
            URL metaWeatherURL = new URL(String.format("https://www.metaweather.com/api/location/%1$s/%2$s", woeID, dateString));
            InputStreamReader reader = new InputStreamReader(metaWeatherURL.openStream());

            //Json structure updated
            ConsolidatedWeather[] data = new Gson().fromJson(reader, ConsolidatedWeather[].class);

            //Prints out each source per day
            if(data.length > 0)
            {
                returnString[0] = data[0].getWeatherStateName();
                returnString[1] = String.valueOf(decimalFormat.format(data[0].getTheTemp()));
                returnString[2] = String.valueOf(decimalFormat.format(data[0].getMinTemp()));
                returnString[3] = String.valueOf(decimalFormat.format(data[0].getMaxTemp()));
                returnString[4] = String.valueOf(decimalFormat.format(data[0].getWindSpeed()));
                returnString[5] = String.valueOf(decimalFormat.format(data[0].getVisibility()));
                returnString[6] = String.valueOf(decimalFormat.format(data[0].getAirPressure()));
                returnString[7] = String.valueOf(decimalFormat.format(data[0].getHumidity()));
            }
            return returnString;
        }
        catch(Exception ex)
        {
            return null;
        }
    }
}
