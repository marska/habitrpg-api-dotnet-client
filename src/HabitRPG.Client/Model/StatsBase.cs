using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class StatsBase
   {
      [JsonProperty("con")]
      public double Con { get; set; }

      [JsonProperty("int")]
      public double Int { get; set; }

      [JsonProperty("per")]
      public double Per { get; set; }

      [JsonProperty("str")]
      public double Str { get; set; }
   }
}
