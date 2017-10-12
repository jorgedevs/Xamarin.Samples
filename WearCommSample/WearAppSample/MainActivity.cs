using Android.App;
using Android.Widget;
using Android.OS;
using Android.Gms.Wearable;
using Android.Gms.Common.Apis;
using Android.Gms.Common;
using System.Linq;
using Android.Runtime;
using System;

namespace WearCommSample
{
    [Activity(Label = "WearAppSample", MainLauncher = true)]
    public class MainActivity : Activity, IDataApiDataListener, GoogleApiClient.IConnectionCallbacks, GoogleApiClient.IOnConnectionFailedListener
    {
        int tapCount;
        Button btnTapCounter;
        TextView lblTapCounter;
        GoogleApiClient client;
        const string SYNC_PATH = "/WearCommSample/Data"; 

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            btnTapCounter = FindViewById<Button>(Resource.Id.btnTapCounter);
            lblTapCounter = FindViewById<TextView>(Resource.Id.lblTapCounter);

            btnTapCounter.Click += BtnTapCounterClick;

            client = new GoogleApiClient.Builder(this, this, this)
                            .AddApi(WearableClass.API)
                            .Build();

            if (!client.IsConnected)
                client.Connect();
        }

        void BtnTapCounterClick(object sender, System.EventArgs e)
        {
            try
            {
                tapCount++;

                var request = PutDataMapRequest.Create(SYNC_PATH);
                request.SetUrgent(); // Use this only to send the message asap
                request.DataMap.PutLong("UpdatedAt", DateTime.UtcNow.Ticks);
                request.DataMap.PutString("TapCounter", tapCount.ToString());
                WearableClass.DataApi.PutDataItem(client, request.AsPutDataRequest());
            }
            catch (Exception ex)
            {
                Android.Util.Log.Error("Exception Occurred: " + ex.Message, "watch");
            }
            //Note: Uncomment only if you want to send a message only once
            //finally
            //{
            //    client.Disconnect();
            //}
        }

        #region Google Api Interface Implementations
        public void OnConnected(Bundle connectionHint)
        {
            WearableClass.DataApi.AddListener(client, this);
        }

        public void OnConnectionSuspended(int cause)
        {
            Android.Util.Log.Error("GMSConnection suspended " + cause, "watch");
            WearableClass.DataApi.RemoveListener(client, this);
        }

        public void OnConnectionFailed(ConnectionResult result)
        {
            Android.Util.Log.Error("GMSConnection failed " + result.ErrorCode, "watch");
        }

        public void OnDataChanged(DataEventBuffer dataEvents)
        {
            var dataEvent = Enumerable.Range(0, dataEvents.Count)
                                      .Select(i => dataEvents.Get(i).JavaCast<IDataEvent>())
                                      .FirstOrDefault(x => x.Type == DataEvent.TypeChanged && x.DataItem.Uri.Path.Equals(SYNC_PATH));

            if (dataEvent == null)
                return;

            //get data from phone
            var dataMapItem = DataMapItem.FromDataItem(dataEvent.DataItem);
            var map = dataMapItem.DataMap;

            tapCount = int.Parse(dataMapItem.DataMap.GetString("TapCounter"));
            lblTapCounter.Text = tapCount.ToString();
        }
        #endregion

        protected override void OnStop()
        {
            base.OnStop();

            client.Disconnect();
        }

        protected override void OnDestroy()
        {
            btnTapCounter.Click -= BtnTapCounterClick;

            base.OnDestroy();
        }
    }
}

