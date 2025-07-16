
namespace ColorMaker
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double red = SliderRed.Value;
            double green = SliderGreen.Value;
            double blue = SliderBlue.Value;
            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }

        private void SetColor(Color color)
        {
            ButtonRandom.BackgroundColor = color;
            Container.BackgroundColor = color;
            LabelHex.Text = color.ToHex();
        }
    }
}
