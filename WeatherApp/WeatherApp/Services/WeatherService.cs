using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    public class WeatherService
    {
        private readonly HttpClient _httpClient;

        public WeatherService()
        {
            _httpClient = new HttpClient();
        }

        public async Task GetWeather(string city)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync($"https://goweather.herokuapp.com/weather/{city}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Weather weather = JsonConvert.DeserializeObject<Weather>(responseBody);

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"\n {city.ToUpper()} Hava Durumu ");
                Console.ForegroundColor = ConsoleColor.White;

                Console.WriteLine($"\nSıcaklık: {weather.Temperature}");

                Console.WriteLine($"Rüzgar: {weather.Wind}");

                Console.WriteLine($"Açıklama: {weather.Description}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTahmin:");
                Console.ForegroundColor = ConsoleColor.White;

                foreach (var forecast in weather.Forecast)
                {
                    Console.WriteLine($"Gün: {forecast.Day}, Sıcaklık: {forecast.Temperature}, Rüzgar: {forecast.Wind}");
                }

                Console.WriteLine();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"Hata: {city} hava durumu verileri alınırken bir hata oluştu: {e.Message}");
            }
        }
    }
}
