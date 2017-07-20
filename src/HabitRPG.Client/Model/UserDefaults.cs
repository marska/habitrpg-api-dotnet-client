using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class UserDefaults
    {
        [JsonProperty("dailys")]
        public List<Daily> Dailys { get; set; }

        [JsonProperty("habits")]
        public List<Habit> Habits { get; set; }

        [JsonProperty("rewards")]
        public List<Reward> Rewards { get; set; }

        [JsonProperty("todos")]
        public List<Todo> Todos { get; set; }

        [JsonProperty("tags")]
        public List<Tag> Tags { get; set; }
    }
}