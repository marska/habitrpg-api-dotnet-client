using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Hair
    {
        [JsonProperty("flower")]
        public int Flower { get; set; }

        [JsonProperty("mustache")]
        public int Mustache { get; set; }

        [JsonProperty("beard")]
        public int Beard { get; set; }

        [JsonProperty("bangs")]
        public int Bangs { get; set; }

        [JsonProperty("base")]
        public int Base { get; set; }

        [JsonProperty("color")]
        public string Color { get; set; }
    }
}