using System;
using System.Threading.Tasks;
using HabitRPG.Client.Common;
using HabitRPG.Client.Model;
using System.Net;
using System.Net.Http;

namespace HabitRPG.Client
{
    public class ContentClient : ClientBase, IContentClient
    {
        public ContentClient(HabitRpgConfiguration habitRpgConfiguration)
          : base(habitRpgConfiguration)
        {
        }

        public ContentClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient)
          : base(habitRpgConfiguration, httpClient)
        {
        }

        public ContentClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler)
          : base(habitRpgConfiguration, httpClientHandler)
        {
        }

        public ContentClient(Guid userId, Guid apiToken, Uri serviceUri)
          : base(userId, apiToken, serviceUri)
        {
        }

        public ContentClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient)
          : base(habitRpgConfiguration, httpClient)
        {
        }

        public async Task<Content> GetContentAsync(string language = "")
        {
            var response = await HttpClient.GetAsync(String.Format("content?language={0}", language));

            return GetResult<Content>(response);
        }
    }
}