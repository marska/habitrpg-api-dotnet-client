using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Item : StatsBase
    {
        [JsonProperty("value")]
        public int Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("klass")]
        public string Klass { get; set; }

        [JsonProperty("index")]
        public string Index { get; set; }

        [JsonProperty("event")]
        public Event Event { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("notes")]
        public string Notes { get; set; }

        public override string ToString()
        {
            return string.Format("[Item: Value={0}, Type={1}, Key={2}, Klass={3}, Index={4}, Event={5}, Text={6}, Notes={7}]", Value, Type, Key, Klass, Index, Event, Text, Notes);
        }
    }
}
