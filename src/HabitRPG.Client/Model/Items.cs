using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HabitRPG.Client.Model
{
   public class Items
   {
      public Items()
      {
         Eggs = new Dictionary<string, int>();
         Mounts = new Dictionary<string, bool>();
         Food = new Dictionary<string, int>();
         Pets = new Dictionary<string, int>();
         HatchingPotions = new Dictionary<string, int>();
      }

      [JsonProperty("currentPet")]
      public String CurrentPet { get; set; }

      [JsonProperty("currentMount")]
      public String CurrentMount { get; set; }

      [JsonProperty("eggs")]
      public Dictionary<String, int> Eggs { get; set; }

      [JsonProperty("pets")]
      public Dictionary<String, int> Pets { get; set; }

      [JsonProperty("mounts")]
      public Dictionary<String, bool> Mounts { get; set; }

      [JsonProperty("hatchingPotions")]
      public Dictionary<String, int> HatchingPotions { get; set; }
         
      [JsonProperty("food")]
      public Dictionary<String, int> Food { get; set; }

      [JsonProperty("Gear")]
      public Gear Gear { get; set; }
   }
}
