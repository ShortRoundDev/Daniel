using Daniel.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Daniel.ApiClients
{
    public class WeatherGovClient
    {
        private const string Nws = "https://api.weather.gov";

        private ILogger logger;
        public WeatherGovClient(ILogger logger)
        {
            this.logger = logger;
        }

        public async Task<WeatherForecast> Forecast(string Office, int GridX, int GridY)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("User-Agent", $"({Environment.GetEnvironmentVariable("HOST_NAME")}, {Environment.GetEnvironmentVariable("CONTACT_EMAIL")})");
                HttpRequestMessage request = new HttpRequestMessage()
                {
                    RequestUri = new Uri($"{Nws}/gridpoints/{Office}/{GridX},{GridY}/forecast", UriKind.Absolute)
                };
                var response = await client.SendAsync(request);
                var message = await response.Content.ReadAsStringAsync();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    logger.LogError($"Failed to get forecast at {Office}:{GridX},{GridY}! Got {response.StatusCode}:\n{message}");
                    return null;
                }
                WeatherForecast forecast = null;
                try
                {

                    forecast = JsonSerializer.Deserialize<WeatherForecast>(message, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                }catch(Exception e)
                {
                    logger.LogError($"Failed to deserialize JSON Response at {Office}:{GridX},{GridY}! Got {e.Message}");
                }

                return forecast;
            }
        }
    }
}
