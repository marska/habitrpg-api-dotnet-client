using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class Stats : StatsBase
   {
      [JsonProperty("buffs")]
      public Buffs Buffs { get; set; }

      [JsonProperty("class")]
      public string Class { get; set; }

      [JsonProperty("exp")]
      public double Exp { get; set; }

      [JsonProperty("gp")]
      public double Gold { get; set; }

      [JsonProperty("hp")]
      public double HP { get; set; }

      [JsonProperty("lvl")]
      public int Lvl { get; set; }

      [JsonProperty("mp")]
      public double MP { get; set; }

      [JsonProperty("training")]
      public StatsBase Training { get; set; }

      [JsonProperty("toNextLevel")]
      public int ToNextLevel { get; set; }
      
      [JsonProperty("maxHealth")]
      public int MaxHealth { get; set; }

      [JsonProperty("maxMP")]
      public int MaxMP { get; set; }
   }
}
