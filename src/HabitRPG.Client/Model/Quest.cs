using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Quest
    {
        [JsonProperty("leader")]
        public Guid Leader { get; set; }

        [JsonProperty("members")]
        public Dictionary<Guid, string> Members { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("progress")]
        public object Progress { get; set; }
    }
}