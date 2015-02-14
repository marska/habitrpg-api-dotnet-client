using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using HabitRPG.Client.Converters;

namespace HabitRPG.Client.Model
{
	public class Status
	{
		[JsonProperty("status")]
		public string ServerStatus { get; set; }
	}
}