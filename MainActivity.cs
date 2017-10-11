using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;

namespace HextoRGBConverter
{
    [Activity(Label = "HextoRGBConverter", MainLauncher = true, Icon = "@mipmap/icon")]
    public class MainActivity : Activity
    {

        EditText hexValueEditText;
        TextView redTextView, greenTextView, blueTextView;
        Button calculateButton;
        View colorView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            hexValueEditText = FindViewById<EditText>(Resource.Id.hexValueEditText);
            redTextView = FindViewById<TextView>(Resource.Id.redTextView);
            greenTextView = FindViewById<TextView>(Resource.Id.greenTextView);
            blueTextView = FindViewById<TextView>(Resource.Id.blueTextView);
            calculateButton = FindViewById<Button>(Resource.Id.calculateButton);
            colorView = FindViewById<View>(Resource.Id.colorView);

            calculateButton.Click+= CalculateButton_Click;
        }

        private void CalculateButton_Click(object sender, System.EventArgs e)
        {
            string hexValue = hexValueEditText.Text;
            string redHexValue = hexValue.Substring(0, 2);
            string greenHexValue = hexValue.Substring(2, 2);
            string blueHexValue = hexValue.Substring(4, 2);

            int redValue = int.Parse(redHexValue, System.Globalization.NumberStyles.HexNumber);
            int greenValue = int.Parse(greenHexValue, System.Globalization.NumberStyles.HexNumber);
            int blueValue = int.Parse(blueHexValue, System.Globalization.NumberStyles.HexNumber);

            redTextView.Text = redValue.ToString();
            greenTextView.Text = greenValue.ToString();
            blueTextView.Text = blueValue.ToString();

            colorView.SetBackgroundColor(new Android.Graphics.Color(redValue, greenValue, blueValue));
        }
    }
}

