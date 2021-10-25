using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daniel.Models
{
    public class WeatherForecast
    {
        public string Type { get; set; }
        public object Geometry { get; set; }
        public WeatherForecastProperties Properties { get; set; }
    }
}
