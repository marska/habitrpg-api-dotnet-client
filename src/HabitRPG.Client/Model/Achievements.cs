using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
   
	public class Achievements
	{
		[JsonProperty("challenges")]
		public List<string> Challenges { get; set; }

		[JsonProperty("perfect")]
		public int Perfect { get; set; }

		[JsonProperty("streak")]
		public int Streak { get; set; }

		[JsonProperty("quests")]
		public Dictionary<string, int> Quests { get; set; }

	}
}