using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Food : Drop
    {
        [JsonProperty("article")]
        public string Article { get; set; }

        [JsonProperty("canBuy")]
        public bool CanBuy { get; set; }

        [JsonProperty("canDrop")]
        public bool CanDrop { get; set; }

        [JsonProperty("target")]
        public string Target { get; set; }
    }
}