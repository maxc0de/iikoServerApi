using Newtonsoft.Json;

namespace IikoServerApi
{
    public class OlapReport<T>
    {
        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
}
