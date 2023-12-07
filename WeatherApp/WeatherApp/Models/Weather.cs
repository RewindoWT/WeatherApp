using System.Collections.Generic;

namespace WeatherApp
{
    public class Weather
    {
        public string Temperature { get; set; } = String.Empty;
        public string Wind { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public List<Forecast> Forecast { get; set; }
    }

    public class Forecast
    {
        public string Day { get; set; } = String.Empty;
        public string Temperature { get; set; } = String.Empty;
        public string Wind { get; set; } = String.Empty;
    }
}
