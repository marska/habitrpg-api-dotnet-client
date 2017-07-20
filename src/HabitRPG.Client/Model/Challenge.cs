using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HabitRPG.Client.Model
{
    public class Challenge
    {
        /// <summary>
        /// When we use Task
        /// </summary>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        /// When we use Group
        /// </summary>
        [JsonProperty("_id")]
        public Guid Id2 { get; set; }

        [JsonProperty("broken")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Broken Broken { get; set; }

        [JsonProperty("winner")]
        public string Winner { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}