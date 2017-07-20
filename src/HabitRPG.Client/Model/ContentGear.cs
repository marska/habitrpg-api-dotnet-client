using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class ContentGear
    {
        [JsonProperty("flat")]
        public Dictionary<String, Item> Flat { get; set; }
    }
}
