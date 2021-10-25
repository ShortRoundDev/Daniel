using System;

namespace Daniel.Models
{
    public class ClimateHistory
    {
        public DateOnly Date { get; set; }
        public float PrecipitationAverage { get; set; }
        public float PrecipitationYtdAverage { get; set; }
        public float PrecipitationYearlyAverage { get; set; }
    }
}
