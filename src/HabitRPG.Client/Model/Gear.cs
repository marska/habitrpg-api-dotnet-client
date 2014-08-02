using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HabitRPG.Client.Model
{
   public class Gear
   {
      public Gear()
      {
         Costume = new Dictionary<string, string>();
         Equipped = new Dictionary<string, string>();
         Owned = new Dictionary<string, string>();
      }

      [JsonProperty("costume")]
      public Dictionary<String, String> Costume { get; set; }

      [JsonProperty("equipped")]
      public Dictionary<String, String> Equipped { get; set; }

      [JsonProperty("owned")]
      public Dictionary<String, String> Owned { get; set; }
   }
}
