namespace Xam.App.Services
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Text;
    using System.Web;
    using ViewModels;
    using Xam.App.Entities;

    public class Apiservice
    {
        public void SearchWeather()
        {
            var instance = MainViewModel.GetInstance();
            try
            {
                var client = new WebClient();
                var encodedParameter = HttpUtility.UrlEncode(instance.SearchString.ToString());
                var formattedUrl = $"{instance.Endpoint}&q={encodedParameter}";
                var url = new Uri(formattedUrl);
                var resultString = client.DownloadString(url);
                client.Dispose();
                var resultObject = JsonConvert.DeserializeObject<WeatherResponse>(resultString);
                instance.Weather = resultObject;
                instance.Weather.LastDateConsulted = DateTime.UtcNow;
        

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "ok");
            }
        }
    }
}
