using Android.App;
using Android.Widget;
using Android.OS;

namespace WearCommSample
{
    [Activity(Label = "WearAppSample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int TapCount;
        Button btnTapCounter;
        TextView lblTapCounter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            btnTapCounter = FindViewById<Button>(Resource.Id.btnTapCounter);
            lblTapCounter = FindViewById<TextView>(Resource.Id.lblTapCounter);

            btnTapCounter.Click += BtnTapCounterClick;
        }

        void BtnTapCounterClick(object sender, System.EventArgs e)
        {
            TapCount++;
            lblTapCounter.Text = TapCount.ToString();
        }

        protected override void OnDestroy()
        {
            btnTapCounter.Click -= BtnTapCounterClick;

            base.OnDestroy();
        }
    }
}

