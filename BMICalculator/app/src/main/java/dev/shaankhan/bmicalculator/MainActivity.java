package dev.shaankhan.bmicalculator;

import android.view.View;
import android.widget.TextView;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;

public class MainActivity extends AppCompatActivity
{
    public enum Gender
    {
        Male,
        Female,
        Null
    }

    Gender usersGender = Gender.Null;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void MaleButton_Click(View v)
    {
        usersGender = Gender.Male;
    }

    public void FemaleButton_Click(View v)
    {
        usersGender = Gender.Female;
    }

    public void CalculateButton_Click(View v)
    {
        //Ignores if gender is null or either of the text inputs are null else toast occurs
        TextView mHeight = (TextView) findViewById(R.id.heightEditText);
        TextView mWeight = (TextView) findViewById(R.id.weightEditText);

        if((!mHeight.getText().toString().isEmpty() && !mWeight.getText().toString().isEmpty()) && usersGender != Gender.Null)
        {
            double height = Double.valueOf(mHeight.getText().toString());
            double weight = Double.valueOf(mWeight.getText().toString());

            double bmiValue = CalculateBMI(height, weight);
            String bmiComment = CalculateBMIComment(bmiValue);

            TextView bmiTextView = (TextView) findViewById(R.id.bmiTextView);
            bmiTextView.setText(String.valueOf(bmiValue));

            //Calculate BMI Comment
            TextView bmiCommentTextView = (TextView) findViewById(R.id.bmiCommentTextView);
            bmiCommentTextView.setText(bmiComment);
        }
        else
        {

        }
    }

    public double CalculateBMI(double height, double weight)
    {
        return weight / Math.pow((height / 100), 2);
    }

    public String CalculateBMIComment(double bmiValue)
    {
        String returnString;

        if(bmiValue < 18.5)
        {
            returnString = "Underweight";
        }
        else if(bmiValue < 24.9)
        {
            returnString = "Normal";
        }
        else if(bmiValue < 29.9)
        {
            returnString = "Overweight";
        }
        else if(bmiValue < 34.9)
        {
            returnString = "Obese";
        }
        else
        {
            returnString = "Extremely Obese";
        }

        return returnString;
    }
}
