using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
   public class Member
   {
      [JsonProperty("balance")]
      public double Balance { get; set; }
      
      [JsonProperty("id")]
      public Guid Id { get; set; }

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

		[JsonProperty("contributor")]
		public Contributor Contributor { get; set; }

		[JsonProperty("auth")]
		public Authentication Authentication { get; set; }

		[JsonProperty("achievements")]
		public Achievements Achievements { get; set; }

   }
}