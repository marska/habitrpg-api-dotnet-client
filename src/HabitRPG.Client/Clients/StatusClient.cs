using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HabitRPG.Client.Common;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
	public class StatusClient : ClientBase, IStatusClient
	{
		public StatusClient(HabitRpgConfiguration habitRpgConfiguration)
			: base(habitRpgConfiguration)
		{
		}

		public StatusClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient)
			: base(habitRpgConfiguration, httpClient)
		{
		}

		public StatusClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler)
			: base(habitRpgConfiguration, httpClientHandler)
		{
		}

		public StatusClient(Guid userId, Guid apiToken, Uri serviceUri)
			: base(userId, apiToken, serviceUri)
		{
		}

		public StatusClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient)
			: base(habitRpgConfiguration, httpClient)
		{
		}

		public async Task<Status> GetStatusAsync()
		{
			var response = await HttpClient.GetAsync("status");

			return GetResult<Status>(response);
		}
	}
}