using System;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.WriteLine("Şehir seçiniz: ");
                Console.WriteLine("1. İstanbul");
                Console.WriteLine("2. İzmir");
                Console.WriteLine("3. Ankara");
                Console.WriteLine("0. Çıkış");

                Console.Write("Seçiminiz (0-3):");


                

                string choice = Console.ReadLine();
                
                if (choice == "0")
                    break;
               
                string city = GetCityFromChoice(choice);
               

                if (city != null)
                {
                    var weatherService = new WeatherService();
                    await weatherService.GetWeather(city);
                  
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Hatalı seçim! Lütfen geçerli bir seçenek girin.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
        }
        
        static string GetCityFromChoice(string choice)
        {
            
            switch (choice)
            {

                case "1":
                    return "istanbul";
                case "2":
                    return "izmir";
                case "3":
                    return "ankara";
                default:
                    return null;
            }
        }
    }
}
