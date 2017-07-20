using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HabitRPG.Client.Model
{
    public class WebHook
    {
        [JsonProperty("sort")]
        public int Sort { get; set; }

        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("enabled")]
        public bool Enabled { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
