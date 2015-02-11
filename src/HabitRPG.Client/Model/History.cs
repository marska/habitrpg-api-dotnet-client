using System;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
	public class History
	{
		[JsonConverter(typeof(TimestampConverter))]
		[JsonProperty("date")]
		public DateTime Date { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }
	}
}
