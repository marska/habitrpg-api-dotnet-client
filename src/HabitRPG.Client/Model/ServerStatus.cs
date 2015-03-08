using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
	public class ServerStatus
	{
		/// <summary>
		/// Gets or sets the server status.
		/// </summary>
		/// <value>'up', if the server is up</value>
		[JsonProperty("status")]
		public string Status { get; set; }
	}
}