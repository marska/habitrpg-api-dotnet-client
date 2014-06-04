using System;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
  public class History
  {
    [JsonProperty("date")]
    public DateTime Date { get; set; }

    [JsonProperty("value")]
    public double Value { get; set; }
  }
}
