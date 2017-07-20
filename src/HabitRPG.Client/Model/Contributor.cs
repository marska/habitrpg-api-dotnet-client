using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Contributor
    {
        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("level")]
        public int Level { get; set; }

        [JsonProperty("contributions")]
        public string Contributions { get; set; }

        [JsonProperty("critical")]
        public string Critical { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }
    }
}