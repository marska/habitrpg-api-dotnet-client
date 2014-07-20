using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class Items
   {
      public Items()
      {
         Eggs = new Dictionary<string, int>();
         Mounts = new Dictionary<string, int>();
         Food = new Dictionary<string, int>();
         Pets = new Dictionary<string, int>();
      }

      [JsonProperty("currentPet")]
      public String CurrentPet { get; set; }

      [JsonProperty("eggs")]
      public Dictionary<String, int> Eggs { get; set; }

      [JsonProperty("pets")]
      public Dictionary<String, int> Pets { get; set; }

      [JsonProperty("mounts")]
      public Dictionary<String, int> Mounts { get; set; }

      [JsonProperty("food")]
      public Dictionary<String, int> Food { get; set; }


      [JsonProperty("gear")]
      public Gear gear { get; set; }
   }
}
