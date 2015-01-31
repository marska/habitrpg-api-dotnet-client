using Newtonsoft.Json;
using System;

namespace HabitRPG.Client.Model
{
	public class Tag
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("challenge")]
		public string Challenge { get; set; }
	}
}
