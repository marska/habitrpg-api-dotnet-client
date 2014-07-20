using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class Stats : StatsBase
   {
      [JsonProperty("class")]
      public string Class { get; set; }

      [JsonProperty("exp")]
      public int Exp { get; set; }

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
