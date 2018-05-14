using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace RgbLedAppSample
{
    public class ApiHelper
    {
        private string _apiBase = "";

        public ApiHelper() { }

        async public Task<string> CheckStatus()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + App.HostAddress + "/" + _apiBase);

            var response = await client.GetAsync("status");
            if (response.IsSuccessStatusCode)
            {
                var result = JObject.Parse(await response.Content.ReadAsStringAsync());
                return result["status"].Value<string>();
            }
            else
            {
                throw new InvalidOperationException("Could not connect to device");
            }
        }

        async public Task<bool> Connect()
        {
            HttpClient client = new HttpClient();
            client.Timeout = new TimeSpan(0, 0, 0, 3, 0);
            client.BaseAddress = new Uri("http://" + App.HostAddress + "/" + _apiBase);

            try
            {
                var response = await client.GetAsync("status");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        async private Task<bool> PowerCommand(string command)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + App.HostAddress + "/" + _apiBase);

            var response = await client.PostAsync(command, null);

            if (response.IsSuccessStatusCode)
            {
                if (command == "turnon")
                {
                    App.LedStatus = LedStatus.On;
                }
                else
                {
                    App.LedStatus = LedStatus.Off;
                }
            }
            return response.IsSuccessStatusCode;
        }
    }
}
