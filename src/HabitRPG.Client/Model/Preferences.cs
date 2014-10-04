using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class Preferences
   {
      [JsonProperty("language")]
      public string Language { get; set; }

      [JsonProperty("shirt")]
      public string Shirt { get; set; }

      [JsonProperty("skin")]
      public string Skin { get; set; }

      [JsonProperty("size")]
      public string Size { get; set; }

      [JsonProperty("hair")]
      public Hair Hair { get; set; }

      [JsonProperty("costume")]
      public bool Costume { get; set; }

      [JsonProperty("sleep")]
      public bool Sleep { get; set; }

      [JsonProperty("background")]
      public string Background { get; set; }

      [JsonProperty("dayStart")]
      public int DayStartsAt { get; set; }
   }
}
