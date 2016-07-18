using Xamarin.Forms;

namespace StatusBarEffectDemo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            StatusBarEffect.SetBackgroundColor(Color.Green);
            this.Effects.Add(new StatusBarEffect());
        }
    }
}
