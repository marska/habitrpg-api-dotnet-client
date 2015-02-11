using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Buffs : StatsBase
	{
		[JsonProperty("snowball")]
		public bool Snowball { get; set; }

		[JsonProperty("spookdust")]
		public bool SpookyDust { get; set; }

		[JsonProperty("stealth")]
		public int Stealth { get; set; }

		[JsonProperty("streaks")]
		public bool Streaks { get; set; }
	}
}
