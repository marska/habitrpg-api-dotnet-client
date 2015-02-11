using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HabitRPG.Client.Model
{
	public class Preferences
	{
		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("shirt")]
		public string Shirt { get; set; }

		[JsonProperty("skin")]
		public string Skin { get; set; }

		[JsonProperty("size")]
		public string Size { get; set; }

		[JsonProperty("hair")]
		public Hair Hair { get; set; }

		[JsonProperty("costume")]
		public bool Costume { get; set; }

		[JsonProperty("sleep")]
		public bool Sleep { get; set; }

		[JsonProperty("background")]
		public string Background { get; set; }

		[JsonProperty("dayStart")]
		public int DayStartsAt { get; set; }

		[JsonProperty("webhooks")]
		public Dictionary<Guid, WebHook> Webhooks { get; set; }

		[JsonProperty("toolbarCollapsed")]
		public bool ToolbarCollapsed { get; set; }

		[JsonProperty("advancedCollapsed")]
		public bool AdvancedCollapsed { get; set; }

		[JsonProperty("tagsCollapsed")]
		public bool TagsCollapsed { get; set; }

		[JsonProperty("dailyDueDefaultView")]
		public bool DailyDueDefaultView { get; set; }

		[JsonProperty("newTaskEdit")]
		public bool NewTaskEdit { get; set; }

		[JsonProperty("disableClasses")]
		public bool DisableClasses { get; set; }

		[JsonProperty("stickyHeader")]
		public bool StickyHeader { get; set; }

		[JsonProperty("allocationMode")]
		public string AllocationMode { get; set; }

		[JsonProperty("sound")]
		public string Sound { get; set; }

		[JsonProperty("hideHeader")]
		public bool HideHeader { get; set; }

		[JsonProperty("timezoneOffset")]
		public int TimezoneOffset { get; set; }

		[JsonProperty("automaticAllocation")]
		public bool AutomaticAllocation { get; set; }
	}
}
