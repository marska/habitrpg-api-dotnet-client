using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HabitRPG.Client.Model
{
	[JsonConverter(typeof(StringEnumConverter))]
	public enum Broken
	{
		[EnumMember(Value = "CHALLENGE_DELETED")]
		ChallengeDeleted,

		[EnumMember(Value = "TASK_DELETED")]
		TaskDeleted,

		[EnumMember(Value = "UNSUBSCRIBED")]
		Unsubscribed,

		[EnumMember(Value = "CHALLENGE_CLOSED")]
		ChallengeClosed,
	}
}