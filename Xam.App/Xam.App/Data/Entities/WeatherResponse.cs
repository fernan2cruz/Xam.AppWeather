namespace Xam.App.Entities
{
    using System;
    public class WeatherResponse
    {
        public Location location { get; set; }
        public Weather current { get; set; }
        public DateTime? LastDateConsulted { get; set; }
    }
}
