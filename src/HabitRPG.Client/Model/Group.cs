using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class Group
    {
        /// <summary>
        /// DataType is String because the Tavern has the GroupId: habitrpg
        /// </summary>
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("balance")]
        public double Balance { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("leader")]
        public Member Leader { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("memberCount")]
        public int MemberCount { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("logo")]
        public string Logo { get; set; }

        [JsonProperty("quest")]
        public Quest Quest { get; set; }

        [JsonProperty("chat")]
        public List<ChatMessage> Chat { get; set; }

        [JsonProperty("members")]
        public List<Member> Members { get; set; }

        [JsonProperty("challengeCount")]
        public int ChallengeCount { get; set; }

        [JsonProperty("challenges")]
        public List<Challenge> Challenges { get; set; }
    }
}