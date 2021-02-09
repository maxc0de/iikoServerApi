using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace IikoApi
{
    public class ReportRequest
    {
        [JsonProperty("reportType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public ReportType ReportType { get; set; }

        [JsonProperty("buildSummary")]
        public bool BuildSummary { get; set; } = true;

        [JsonProperty("groupByRowFields")]
        public List<string> GroupByRowFields { get; set; } = new List<string>();

        [JsonProperty("groupByColFields")]
        public List<string> GroupByColFields { get; set; } = new List<string>();

        [JsonProperty("aggregateFields")]
        public List<string> AggregateFields { get; set; } = new List<string>();

        [JsonProperty("filters")]
        public Dictionary<string, object> Filters { get; set; } = new Dictionary<string, object>();
    }
}
