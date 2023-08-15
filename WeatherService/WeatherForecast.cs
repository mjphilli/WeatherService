using System.Text.Json.Serialization;

namespace WeatherService
{
    public class WeatherForecast
    {
        public string? Date { get; set; }

        //public double Celcius { get; set; }

        //public double Fahrenheit => (double)(Celcius * 1.8) + 32;

        public Dictionary<string, double>? Temperature { get; set; }
        public string? Summary { get; set; }
    }
}