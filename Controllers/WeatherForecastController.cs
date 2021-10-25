using Daniel.ApiClients;
using Daniel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daniel.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger _logger;

        public WeatherForecastController(ILogger logger = null)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<WeatherForecast> Get()
        {
            var client = new WeatherGovClient(_logger);
            return await client.Forecast("LWX", 84, 72);
        }
    }
}
