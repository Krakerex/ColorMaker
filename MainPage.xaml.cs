using CommunityToolkit.Maui.Alerts;
using System.Diagnostics;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexvalue="#000000";

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                var red = sldRed.Value;
                var green = sldGreen.Value;
                var blue = sldBlue.Value;

                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            btnRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexvalue = color.ToHex();
            lblHex.Text = hexvalue;
        }

        private void btnRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            var random = new Random();
            var color = Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
            sldBlue.Value = color.Blue;
            sldGreen.Value = color.Green;
            sldRed.Value = color.Red;
            SetColor(color);
            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexvalue);
            var toast = Toast.Make("Color copied!", CommunityToolkit.Maui.Core.ToastDuration.Short,12);
            await toast.Show();
        }
    }
}