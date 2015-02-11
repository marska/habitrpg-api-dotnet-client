using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class Daily : Task
	{
		public override string Type
		{
			get { return "daily"; }
		}

		[JsonProperty("history")]
		public List<History> History { get; set; }

		[JsonProperty("completed")]
		public bool Completed { get; set; }

		[JsonProperty("repeat")]
		public Repeat Repeat { get; set; }

		[JsonProperty("collapseChecklist")]
		public bool CollapseChecklist { get; set; }

		[JsonProperty("checklist")]
		public List<Checklist> Checklist { get; set; }

		[JsonProperty("streak")]
		public double Streak { get; set; }
	}
}