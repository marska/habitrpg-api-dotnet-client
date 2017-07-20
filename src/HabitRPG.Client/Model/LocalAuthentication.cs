using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
    public class LocalAuthentication
    {
        [JsonProperty("username")]
        public String Username { get; set; }

        [JsonProperty("email")]
        public String Email { get; set; }
    }
}