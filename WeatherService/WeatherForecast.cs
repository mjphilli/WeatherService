using System.Text.Json.Serialization;

namespace WeatherService
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int Celcius { get; set; }

        //public int Fahrenheit => 32 + (int)(Celcius / 0.5556);
        public int Fahrenheit => (int)(Celcius * 1.8) + 32;

        public string? Summary { get; set; }
    }
}