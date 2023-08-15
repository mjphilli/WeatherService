using System.Text.Json;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WeatherService.Implementations
{
    public class WeatherForecastImplementation
    {
        internal static async Task<WeatherForecast> GetWeatherForecast(int postal_code)
        {
            //todo: retreive current temperature from:
            //https://www.weatherbit.io/api/swaggerui/weather-api-v2#!/Current32Weather32Data/get_current_postal_code_postal_code
            //using API Key: 1824631bbfa74729aac7d2d2f1dfdd76

            HttpClient client = new HttpClient();
            WeatherForecast forecast = null;
            string url = $"https://api.weatherbit.io/v2.0/current?postal_code={postal_code}&key=1824631bbfa74729aac7d2d2f1dfdd76";
            
            HttpResponseMessage response =  await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                //forecast = JsonConvert.DeserializeObject<WeatherForecast>(responseBody);
                JObject json = JObject.Parse(responseBody);
                double temp = (double)json["data"][0]["temp"];
                forecast = new WeatherForecast()
                {
                    Date = (string)json["data"][0]["datetime"],
                    //Celcius = (double)json["data"][0]["temp"]
                    Temperature = new Dictionary<string, double> 
                    {
                        { "celcius", temp},
                        { "fahrenheit", (double)(temp * 1.8) + 32}
                    }
                };

                Console.WriteLine(forecast.Date);
                Console.WriteLine(forecast.Temperature["celcius"]);
                Console.WriteLine(forecast.Temperature["fahrenheit"]);
            }
            return forecast;
        }
    }
}
