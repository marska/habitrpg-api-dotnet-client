using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
    public class Authentication
    {
        [JsonProperty("local")]
        public LocalAuthentication Local { get; set; }

        [JsonProperty("timestamps")]
        public TimeAuthentication Timestamps { get; set; }
    }
}