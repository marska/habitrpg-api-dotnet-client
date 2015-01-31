using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
  public class Habit : Task
  {
    public override string Type
    {
      get { return "habit"; }
    }

    public Habit()
    {
      Up = true;
      Down = true;
    }

    [JsonProperty("history")]
    public List<History> History { get; set; }

    [JsonProperty("up")]
    public bool Up { get; set; }

    [JsonProperty("down")]
    public bool Down { get; set; }
  }
}