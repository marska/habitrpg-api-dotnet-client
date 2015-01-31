using System.Runtime.Serialization;

namespace HabitRPG.Client.Model
{
	public enum Attribute
	{
		[EnumMember(Value = "str")]
		Strength,

		[EnumMember(Value = "per")]
		Perception,

		[EnumMember(Value = "con")]
		Constitution,

		[EnumMember(Value = "int")]
		Intelligence,
	}
}
