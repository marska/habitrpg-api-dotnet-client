using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
    public class ApiResponse<T>
    {
        public ApiResponse()
        {
        }

        [JsonProperty("success")]
        public bool? Success { get; protected set; }

        [JsonProperty("data")]
        public T Data { get; protected set; }
    }
}
