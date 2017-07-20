using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace HabitRPG.Client.Model
{
    public class User : Member
    {
        [JsonProperty("dailys")]
        public List<Daily> Dailys { get; set; }

        [JsonProperty("habits")]
        public List<Habit> Habits { get; set; }

        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; set; }

        [JsonProperty("todos")]
        public List<Todo> Todos { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }

        [JsonProperty("challenges")]
        public List<Guid> Challenges { get; set; }
    }
}