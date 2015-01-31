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

		public override string ToString()
		{
			return string.Format("[Member: Balance={0}, Id={1}, Items={2}, Profile={3}, Stats={4}, Tags={5}, Preferences={6}, Contributor={7}, Authentication={8}]", Balance, Id, Items, Profile, Stats, Tags, Preferences, Contributor, Authentication);
		}

		[JsonProperty("achievements")]
		public Achievements Achievements { get; set; }

	}
}