using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace HextoRGBConverter
{
    [Activity(Label = "HextoRGBConverter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        // Assigned IDs for app's components
        EditText hexValueEditText;
        TextView redTextView, greenTextView, blueTextView;
        Button calculateButton;
        View colorView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Link to IDs
            hexValueEditText = FindViewById<EditText>(Resource.Id.hexValueEditText);
            redTextView = FindViewById<TextView>(Resource.Id.redTextView);
            greenTextView = FindViewById<TextView>(Resource.Id.greenTextView);
            blueTextView = FindViewById<TextView>(Resource.Id.blueTextView);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            colorView = FindViewById<View>(Resource.Id.colorView);

            // Convert button
            calculateButton.Click+= CalculateButton_Click;
        }

        // Activates when the button is pressed
        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            // Variables - refer to iOS version
            string hexValue = hexValueEditText.Text;
            string redHexValue = hexValue.Substring(0, 2);
            string greenHexValue = hexValue.Substring(2, 2);
            string blueHexValue = hexValue.Substring(4, 2);

            // Value converters - similar to iOS version
            int redValue = int.Parse(redHexValue, System.Globalization.NumberStyles.HexNumber);
            int greenValue = int.Parse(greenHexValue, System.Globalization.NumberStyles.HexNumber);
            int blueValue = int.Parse(blueHexValue, System.Globalization.NumberStyles.HexNumber);

            // Displays converted values - similar to iOS version
            redTextView.Text = redValue.ToString();
            greenTextView.Text = greenValue.ToString();
            blueTextView.Text = blueValue.ToString();

            // Invisible colour changing area - similar to iOS version
            colorView.SetBackgroundColor(new Android.Graphics.Color(redValue, greenValue, blueValue));
        }
    }
}

