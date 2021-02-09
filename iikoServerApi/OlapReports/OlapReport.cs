using Newtonsoft.Json;

namespace IikoApi
{
    public class OlapReport<T>
    {
        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
}
