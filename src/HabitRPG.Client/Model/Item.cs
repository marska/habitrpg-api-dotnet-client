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
   }

   public class Event
   {
      [JsonProperty("start")]
      public string Start { get; set; }

      [JsonProperty("end")]
      public string End { get; set; }
   }
}
