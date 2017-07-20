using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class ScoreResult : Stats
    {
        /// <summary>
        /// Delta of the added Task.Value
        /// </summary>RandomReward
        [JsonProperty("delta")]
        public double Delta { get; set; }

        [JsonProperty("_tmp")]
        public RandomReward RandomReward { get; set; }

        [JsonProperty("buffs")]
        public Buffs Buffs { get; set; }

        [JsonProperty("points")]
        public double Points { get; set; }
    }
}
