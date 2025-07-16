
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Diagnostics;

namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        bool isRandom;
        string hexValue = default!;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (!isRandom)
            {
                double red = SliderRed.Value;
                double green = SliderGreen.Value;
                double blue = SliderBlue.Value;
                Color color = Color.FromRgb(red, green, blue);
                SetColor(color);
            }
        }

        private void SetColor(Color color)
        {
            ButtonRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            hexValue = color.ToHex();
            LabelHex.Text = hexValue;
        }

        private void ButtonRandom_Clicked(object sender, EventArgs e)
        {
            isRandom = true;
            Random random = Random.Shared;
            Color color = Color.FromRgb(random.Next(256), random.Next(256), random.Next(256));
            SetColor(color);
            SliderRed.Value = color.Red;
            SliderGreen.Value = color.Green;
            SliderBlue.Value = color.Blue;
            isRandom = false;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(hexValue);
            IToast? toast = Toast.Make("Color copied", ToastDuration.Short, 12);
            await toast.Show();
        }
    }
}
