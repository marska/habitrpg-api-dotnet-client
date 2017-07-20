using System;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Checklist
    {
        [JsonProperty("completed")]
        public bool Completed { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }
    }
}
