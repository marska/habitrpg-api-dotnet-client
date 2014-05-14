using System.Runtime.Serialization;

namespace HabitRPG.Client.Model
{
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