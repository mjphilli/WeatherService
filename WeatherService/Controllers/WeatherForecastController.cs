using Microsoft.AspNetCore.Mvc;

namespace WeatherService.Controllers
{
    [ApiController]
    [Route("weather")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly Dictionary<int, string> Summaries = new Dictionary<int, string>(){{0,
            "Freezing" }, {4,"Bracing" }, {10,"Chilly" } , {16,"Cool" }, {21,"Mild" }, {27,"Warm" }, {32,"Hot" }, {38,"Sweltering" }, {43,"Scorching" }
        };

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetForecast")]
        public WeatherForecast Get(int postal_code)
        {
            WeatherForecast forecast = WeatherService.Implementations.WeatherForecastImplementation.GetWeatherForecast(postal_code).Result;

            //todo: set Summary value on forecast response using Summaries data dictionary
            try
            { 
                int summaryKey = Summaries.Keys.Where(key => key < forecast.Temperature["celcius"]).Max();
                forecast.Summary = Summaries[summaryKey];
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return forecast;
        }
    }
}