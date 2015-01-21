using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{

	public class TimeAuthentication
	{
		[JsonConverter(typeof(TimestampConverter))]
		[JsonProperty("loggedin")]
		public DateTime LoggedIn { get; set; }

		[JsonConverter(typeof(TimestampConverter))]
		[JsonProperty("created")]
		public DateTime Created { get; set; }
	}
	
}