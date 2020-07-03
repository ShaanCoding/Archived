package dev.shaankhan.bmicalculator;

import android.app.Activity;
import android.graphics.Color;
import android.text.Html;
import android.text.SpannableString;
import android.text.Spanned;
import android.text.style.ForegroundColorSpan;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;
import androidx.appcompat.app.AppCompatActivity;
import android.os.Bundle;
import org.w3c.dom.Text;

public class MainActivity extends Activity
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

        SetUITextColors();
    }

    public void SetUITextColors()
    {
        ForegroundColorSpan fcsBlue = new ForegroundColorSpan(Color.parseColor("#7979FF"));

        String title = "BMI Calculator";
        TextView mTitle = (TextView) findViewById(R.id.textView);
        SpannableString sTitle = new SpannableString(title);

        String height = "Height cm";
        TextView mHeight = (TextView) findViewById(R.id.textView3);
        SpannableString sHeight = new SpannableString(height);

        String weight = "Weight Kgs";
        TextView mWeight = (TextView) findViewById(R.id.textView4);
        SpannableString sWeight = new SpannableString(weight);

        sTitle.setSpan(fcsBlue, 0, 3, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        mTitle.setText(sTitle);

        sHeight.setSpan(fcsBlue, 7, 9, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        mHeight.setText(sHeight);

        sWeight.setSpan(fcsBlue, 7, 10, Spanned.SPAN_EXCLUSIVE_EXCLUSIVE);
        mWeight.setText(sWeight);
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
            String healthyBMIRange = CalculateHealthyRange(height, weight, bmiValue);

            TextView bmiTextView = (TextView) findViewById(R.id.bmiTextView);
            bmiTextView.setText(String.valueOf(Math.round(bmiValue)));

            //Calculate BMI Comment
            TextView bmiCommentTextView = (TextView) findViewById(R.id.bmiCommentTextView);
            bmiCommentTextView.setText(bmiComment);

            //Calculate BMI Range Text
            TextView healthyBMIRangeTextView = (TextView) findViewById(R.id.healthyBMIRangeTextView);
            healthyBMIRangeTextView.setText(healthyBMIRange);
        }
        else
        {
            Toast.makeText(getApplication().getBaseContext(), "Error: Gender not selected", Toast.LENGTH_SHORT).show();
        }
    }

    private String CalculateHealthyRange(double height, double weight, double bmiValue)
    {
        double weightLowerBound = 18.5 * Math.pow((height / 100), 2);
        double weightUpperBound = 24.9 * Math.pow((height / 100), 2);

        return String.format("Healthy BMI range: 18.5 kg/m2 - 25 kg/m2\nHealthy weight for the height: %.2f kgs - %.2f kgs", weightLowerBound, weightUpperBound);
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
