using UnderlineEffectSample.Effects;
using Xamarin.Forms;

namespace UnderlineEffectSample
{
    public partial class MainPage : ContentPage
    {
        bool enableEffect;

        public MainPage()
        {
            InitializeComponent();
            enableEffect = false;
        }

        void BtnEffectClicked(object sender, System.EventArgs e)
        {
            enableEffect = !enableEffect;

            if(enableEffect)
            {
                btnEffect.Text = "Disable Effect";
                lblEffect.Effects.Add(new UnderlineEffect());    
            }
            else
            {
                btnEffect.Text = "Enable Effect";
                lblEffect.Effects.Clear();
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            btnEffect.Clicked += BtnEffectClicked;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            btnEffect.Clicked -= BtnEffectClicked;
        }

        ~MainPage()
        {
            lblTitle.Effects.Clear();
            if (lblEffect.Effects.Count > 0)
                lblEffect.Effects.Clear();
        }
    }
}
