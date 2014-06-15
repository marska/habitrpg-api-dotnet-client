using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HabitRPG.Client.Model
{
  public class Task
  {
    public Task()
    {
      Tags = new Dictionary<Guid, bool>();
      Priority = Difficulty.Easy;
    }

    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("dateCreated")]
    public DateTime DateCreated { get; set; }

    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("notes")]
    public string Notes { get; set; }

    [JsonProperty("tags")]
    public Dictionary<Guid, bool> Tags { get; set; }

    [JsonProperty("value")]
    public double Value { get; set; }

    [JsonProperty("priority")]
    public float Priority { get; set; }

    [JsonProperty("attribute")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Attribute Attribute { get; set; }

    [JsonProperty("challenge")]
    public List<Challenge> Challenge { get; set; }

    [JsonProperty("type")]
    public virtual string Type { get; private set; }
  }
}