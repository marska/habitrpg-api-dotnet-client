using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Content
	{
		[JsonProperty("eggs")]
		public Dictionary<String, Egg> Eggs { get; set; }

		[JsonProperty("dropEggs")]
		public Dictionary<String, Egg> DropEggs { get; set; }

		[JsonProperty("questEggs")]
		public Dictionary<String, Egg> QuestEggs { get; set; }

		[JsonProperty("food")]
		public Dictionary<String, Food> Food { get; set; }

		[JsonProperty("hatchingPotions")]
		public Dictionary<String, int> HatchingPotions { get; set; }

		[JsonProperty("classes")]
		public List<string> Classes { get; set; }

		[JsonProperty("gear")]
		public ContentGear Gear { get; set; }

		[JsonProperty("gearTypes")]
		public List<string> GearTypes { get; set; }

		[JsonProperty("pets")]
		public Dictionary<String, bool> Pets { get; set; }

		[JsonProperty("potion")]
		public Item Potion { get; set; }

		[JsonProperty("questPets")]
		public Dictionary<String, bool> QuestPets { get; set; }

		[JsonProperty("userDefaults")]
		public UserDefaults UserDefaults { get; set; }
	}
}
