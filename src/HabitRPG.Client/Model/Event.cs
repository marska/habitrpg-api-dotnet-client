using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Event
	{
		[JsonProperty("start")]
		public string Start { get; set; }

		[JsonProperty("end")]
		public string End { get; set; }
	}
}
