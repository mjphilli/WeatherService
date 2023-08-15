using System.Text.Json;
using System;

namespace WeatherService.Implementations
{
    public class WeatherForecastImplementation
    {
        static HttpClient client = new HttpClient();
        internal static async Task<WeatherForecast> GetWeatherForecast(int postal_code, string key)
        {
            //todo: retreive current temperature from:
            //https://www.weatherbit.io/api/swaggerui/weather-api-v2#!/Current32Weather32Data/get_current_postal_code_postal_code
            //using API Key: 1824631bbfa74729aac7d2d2f1dfdd76

            //return null;

            //HttpClient client = new HttpClient();
            WeatherForecast forecast = null;

            HttpResponseMessage response = await client.GetAsync($"https://api.weatherbit.io/v2.0/current?postal_code={postal_code}&key={key}");
            if (response.IsSuccessStatusCode)
            {
                forecast = await response.Content.ReadAsAsync<WeatherForecast>();
            }
            return forecast;

            /*string url = $"https://api.weatherbit.io/v2.0/current?postal_code={postal_code}&key={key}";

            var weather = await client.GetFromJsonAsync<WeatherForecast>(key);*/

            /*await using Stream stream = await client.GetStreamAsync($"https://api.weatherbit.io/v2.0/current?postal_code={postal_code}&key={key}");
            forecast = await JsonSerializer.DeserializeAsync<WeatherForecast>(stream);
            return forecast;*/

            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode(); // Throw an exception if error

            //var body = await response.ReadAsStringAsync();
        }

        /*static async Task RunAsync()
        {

        }*/
    }
}
