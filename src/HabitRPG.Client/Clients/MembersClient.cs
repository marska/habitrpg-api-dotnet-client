using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HabitRPG.Client.Common;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
    public class MembersClient : ClientBase, IMembersClient
    {
        public MembersClient(HabitRpgConfiguration habitRpgConfiguration) : base(habitRpgConfiguration)
        {
        }

        public MembersClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient) : base(habitRpgConfiguration, httpClient)
        {
        }

        public MembersClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler) : base(habitRpgConfiguration, httpClientHandler)
        {
        }

        public MembersClient(Guid userId, Guid apiToken, Uri serviceUri) : base(userId, apiToken, serviceUri)
        {
        }

        public MembersClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient) : base(habitRpgConfiguration, httpClient)
        {
        }

        public async Task<Member> GetMemberAsync(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException("id");
            }

            var response = await HttpClient.GetAsync(string.Format("members/{0}", id));

            return GetResult<Member>(response);
        }
    }
}
