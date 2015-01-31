using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Egg : Drop
	{
		[JsonProperty("adjective")]
		public string Adjective { get; set; }

		[JsonProperty("canBuy")]
		public bool CanBuy { get; set; }

		[JsonProperty("mountText")]
		public string MountText { get; set; }
	}
}