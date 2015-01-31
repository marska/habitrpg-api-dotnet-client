using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class StatsBase
   {
      [JsonProperty("con")]
      public double Con { get; set; }

      [JsonProperty("int")]
      public double Int { get; set; }

      [JsonProperty("per")]
      public double Per { get; set; }

      [JsonProperty("str")]
      public double Str { get; set; }

		public static StatsBase operator+(StatsBase one, StatsBase two)
		{
			var result = new StatsBase();
			result.Con = one.Con + two.Con;
			result.Int = one.Int + two.Int;
			result.Per = one.Per + two.Per;
			result.Str = one.Str + two.Str;
			return result;
		}

		public static StatsBase operator+(StatsBase one, int val)
		{
			var result = new StatsBase();
			result.Con = one.Con + val;
			result.Int = one.Int + val;
			result.Per = one.Per + val;
			result.Str = one.Str + val;
			return result;
		}

		public static StatsBase operator+(StatsBase one, double val)
		{
			var result = new StatsBase();
			result.Con = one.Con + val;
			result.Int = one.Int + val;
			result.Per = one.Per + val;
			result.Str = one.Str + val;
			return result;
		}

		public static StatsBase operator-(StatsBase one, StatsBase two)
		{
			var result = new StatsBase();
			result.Con = one.Con - two.Con;
			result.Int = one.Int - two.Int;
			result.Per = one.Per - two.Per;
			result.Str = one.Str - two.Str;
			return result;
		}

		public static StatsBase operator-(StatsBase one, int val)
		{
			var result = new StatsBase();
			result.Con = one.Con - val;
			result.Int = one.Int - val;
			result.Per = one.Per - val;
			result.Str = one.Str - val;
			return result;
		}

		public static StatsBase operator/(StatsBase one, int val)
		{
			var result = new StatsBase();
			result.Con = one.Con / val;
			result.Int = one.Int / val;
			result.Per = one.Per / val;
			result.Str = one.Str / val;
			return result;
		}
   }
}
