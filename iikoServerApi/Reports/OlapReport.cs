using Newtonsoft.Json;

namespace iikoAPIServer
{
    public class OlapReport<T>
    {
        [JsonProperty("data")]
        public T[] Data { get; set; }
    }
}
