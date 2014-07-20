using Newtonsoft.Json;
using System.Collections.Generic;

namespace HabitRPG.Client.Model
{
   public class User
   {
      [JsonProperty("balance")]
      public double Balance { get; set; }

      [JsonProperty("dailys")]
      public List<Daily> Dailys { get; set; }

      [JsonProperty("habits")]
      public List<Habit> Habits { get; set; }

      [JsonProperty("id")]
      public string Id { get; set; }

      [JsonProperty("items")]
      public Items Items { get; set; }

      [JsonProperty("profile")]
      public Profile Profile { get; set; }

      [JsonProperty("rewards")]
      public List<Reward> Rewards { get; set; }

      [JsonProperty("stats")]
      public Stats Stats { get; set; }

      [JsonProperty("tags")]
      public List<Tag> Tags { get; set; }

      [JsonProperty("todos")]
      public List<Todo> Todos { get; set; }

      //public Party Party

      [JsonProperty("preferences")]
      public Preferences Preferences { get; set; }
   }
}