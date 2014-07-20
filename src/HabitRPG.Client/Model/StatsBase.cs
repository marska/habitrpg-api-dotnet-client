using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class StatsBase
   {
      [JsonProperty("con")]
      public int Con { get; set; }

      [JsonProperty("int")]
      public int Int { get; set; }

      [JsonProperty("per")]
      public int Per { get; set; }

      [JsonProperty("str")]
      public int Str { get; set; }
   }
}
