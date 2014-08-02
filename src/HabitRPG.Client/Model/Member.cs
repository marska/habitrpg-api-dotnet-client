using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class Member
   {
      [JsonProperty("balance")]
      public double Balance { get; set; }
      
      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("items")]
      public Items Items { get; set; }

      [JsonProperty("profile")]
      public Profile Profile { get; set; }

      [JsonProperty("stats")]
      public Stats Stats { get; set; }

      [JsonProperty("tags")]
      public List<Tag> Tags { get; set; }

      [JsonProperty("preferences")]
      public Preferences Preferences { get; set; }
   }
}