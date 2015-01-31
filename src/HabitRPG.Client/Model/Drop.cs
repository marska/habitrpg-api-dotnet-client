using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Drop
	{
		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("dialog")]
		public string Dialog { get; set; }

		[JsonProperty("value")]
		public double Value { get; set; }

		[JsonProperty("key")]
		public string Key { get; set; }

		[JsonProperty("notes")]
		public string Notes { get; set; }
	}
}