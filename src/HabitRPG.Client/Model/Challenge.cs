using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HabitRPG.Client.Model
{
	public class Challenge
	{
		[JsonProperty("id")]
		public Guid Id { get; set; }

		[JsonProperty("broken")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Broken Broken { get; set; }

		[JsonProperty("winner")]
		public string Winner { get; set; }
	}
}