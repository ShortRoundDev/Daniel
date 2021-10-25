using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Daniel.Models
{
    public class WeatherForecastProperties
    {
        public DateTime Updated { get; set; }
        public string Units { get; set; }
        public string ForecaseGenerator { get; set; }
        public DateTime GeneratedAt { get; set; }
        public DateTime UpdateTime { get; set; }
        public string ValidTimes { get; set; }
        public WeatherForecastElevation Elevation { get; set; }
        public WeatherForecastPeriod[] Periods { get; set; }
    }
}
