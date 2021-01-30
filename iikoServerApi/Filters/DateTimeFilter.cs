using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace iikoAPIServer
{
    public class DateTimeFilter
    {
        [JsonProperty("filterType")]
        public string FilterType { get; set; } = "DateRange";

        [JsonProperty("periodType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public PeriodType PeriodType { get; set; }

        [JsonProperty("from")]
        public string From { get; set; }

        [JsonProperty("to")]
        public string To { get; set; }

        [JsonProperty("includeLow")]
        public bool IncludeLow { get; set; } = true;

        [JsonProperty("includeHigh")]
        public bool IncludeHigh { get; set; } = true;

        public DateTimeFilter(PeriodType periodType)
        {
            PeriodType = periodType;
        }

        public DateTimeFilter(PeriodType periodType, DateTime from, DateTime to) : this(periodType)
        {
            From = from.ToString("yyyy-MM-dd");
            To = to.ToString("yyyy-MM-dd");
        }
    }
}
