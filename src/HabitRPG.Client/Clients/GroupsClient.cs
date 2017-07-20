using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HabitRPG.Client.Common;
using HabitRPG.Client.Model;
using Task = System.Threading.Tasks.Task;

namespace HabitRPG.Client
{
    public class GroupsClient : ClientBase, IGroupsClient
    {
        public GroupsClient(HabitRpgConfiguration habitRpgConfiguration)
          : base(habitRpgConfiguration)
        {
        }

        public GroupsClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient)
          : base(habitRpgConfiguration, httpClient)
        {
        }

        public GroupsClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler)
          : base(habitRpgConfiguration, httpClientHandler)
        {
        }

        public GroupsClient(Guid userId, Guid apiToken, Uri serviceUri)
          : base(userId, apiToken, serviceUri)
        {
        }

        public GroupsClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient)
          : base(habitRpgConfiguration, httpClient)
        {
        }

        public async Task<List<Group>> GetGroupsAsync(string types)
        {
            if (types == null)
            {
                throw new ArgumentNullException("types");
            }

            var response = await HttpClient.GetAsync(String.Format("groups?type={0}", types));

            return GetResult<List<Group>>(response);
        }

        public async Task<Group> GetGroupAsync(string groupId)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            var response = await HttpClient.GetAsync(String.Format("groups/{0}", groupId));

            return GetResult<Group>(response);
        }

        public async Task<List<ChatMessage>> GetGroupChatAsync(string groupId)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            var response = await HttpClient.GetAsync(String.Format("groups/{0}/chat", groupId));

            return GetResult<List<ChatMessage>>(response);
        }

        public async Task<ChatMessage> SendChatMessageAsync(string groupId, string message)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            var response = await HttpClient.PostAsync(String.Format("groups/{0}/chat?message={1}", groupId, message), null);

            return GetResult<ChatMessage>(response);
        }

        public async Task DeleteChatMessageAsync(string groupId, string messageId)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            if (messageId == null)
            {
                throw new ArgumentNullException("messageId");
            }

            await HttpClient.DeleteAsync(String.Format("groups/{0}/chat/{1}/like", groupId, messageId));
        }

        public async Task LikeChatMessageAsync(string groupId, string messageId)
        {
            if (groupId == null)
            {
                throw new ArgumentNullException("groupId");
            }

            if (messageId == null)
            {
                throw new ArgumentNullException("messageId");
            }

            await HttpClient.PostAsync(String.Format("groups/{0}/chat/{1}/like", groupId, messageId), null);
        }
    }
}
