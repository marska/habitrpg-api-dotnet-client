using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
  public class Todo : Task
  {
    public override string Type
    {
      get { return "todo"; }
      set { throw new NotImplementedException(); }
    }

    [JsonProperty("completed")]
    public bool Completed { get; set; }

    [JsonProperty("archived")]
    public bool Archived { get; set; }

    [JsonProperty("dateCompleted")]
    public DateTime? DateCompleted { get; set; }

    [JsonProperty("date")]
    public DateTime? Date { get; set; }

    [JsonProperty("collapseChecklist")]
    public bool CollapseChecklist { get; set; }

    [JsonProperty("checklist")]
    public List<Checklist> Checklist { get; set; }
  }
}