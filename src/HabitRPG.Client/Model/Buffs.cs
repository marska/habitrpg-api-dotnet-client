using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class Buffs : StatsBase
   {
      [JsonProperty("snowball")]
      public bool Snowball { get; set; }

      [JsonProperty("stealth")]
      public int Stealth { get; set; }

      [JsonProperty("streaks")]
      public bool Streaks { get; set; }
   }
}
