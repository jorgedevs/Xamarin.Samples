using Xamarin.Forms;

namespace RgbLedAppSample
{
	public partial class ConfigurePage : ContentPage
	{
		public ConfigurePage ()
		{
			InitializeComponent ();
		}

        private void EntIpAddressTextChanged(object sender, TextChangedEventArgs e)
        {
            App.HostAddress = ((TextChangedEventArgs)e).NewTextValue;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            entIpAddress.TextChanged += EntIpAddressTextChanged;
        }

        protected override void OnDisappearing()
        {
            entIpAddress.TextChanged -= EntIpAddressTextChanged;

            base.OnDisappearing();
        }
    }
}