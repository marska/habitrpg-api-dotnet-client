using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;

namespace HabitRPG.Client.Model
{
	public interface ITask
	{
		string Id { get; }

		string Type { get; }

		string Text { get; set; }
	}

	public class Task : ITask
	{
		public Task()
		{
			Tags = new Dictionary<Guid, bool>();
			Priority = Difficulty.Easy;
		}

		[JsonProperty("id")]
		public string Id { get; set; }

		[JsonConverter(typeof(IsoDateTimeConverter))]
		[JsonProperty("dateCreated")]
		public DateTime? DateCreated { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }

		[JsonProperty("tags")]
		public Dictionary<Guid, bool> Tags { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }

		[JsonProperty("priority")]
		public float Priority { get; set; }

		[JsonProperty("attribute")]
		[JsonConverter(typeof(StringEnumConverter))]
		public Attribute Attribute { get; set; }

		[JsonProperty("challenge")]
		public Challenge Challenge { get; set; }

		[JsonProperty("type")]
		public virtual string Type { get; private set; }
	}
}