using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace IikoApi
{
    public class ValueFilter
    {
        [JsonProperty("filterType")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FilterType FilterType { get; set; }

        [JsonProperty("values")]
        public List<string> Values { get; set; } = new List<string>();

        public ValueFilter(FilterType filterType, params string[] values)
        {
            FilterType = filterType;

            foreach(var v in values)
            {
                Values.Add(v);
            }
        }
    }
}
