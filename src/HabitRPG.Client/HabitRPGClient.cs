using HabitRPG.Client.Extensions;
using HabitRPG.Client.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Task = System.Threading.Tasks.Task;

namespace HabitRPG.Client
{
   public class HabitRPGClient : IHabitRPGClient, IDisposable
   {
      private readonly HttpClient _httpClient;

      private readonly HabitRpgConfiguration _configuration;
      
      private bool _disposed;

      #region Constructor

      public HabitRPGClient(HabitRpgConfiguration habitRpgConfiguration)
         : this(habitRpgConfiguration, new HttpClient(new HttpClientHandler()))
      {
      }

      public HabitRPGClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient)
         : this(habitRpgConfiguration, new HttpClientHandler { Proxy = httpClient, UseProxy = true })
      {
      }

      public HabitRPGClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler)
         : this(habitRpgConfiguration, new HttpClient(httpClientHandler))
      {
      }

      public HabitRPGClient(Guid userId, Guid apiToken, Uri serviceUri)
         : this(new HabitRpgConfiguration { ApiToken = apiToken, ServiceUri = serviceUri, UserId = userId }, new HttpClient())
      {
      }

      public HabitRPGClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient)
      {
         if (habitRpgConfiguration == null)
         {
            throw new ArgumentNullException("habitRpgConfiguration");
         }

         if (httpClient == null)
         {
            throw new ArgumentNullException("httpClient");
         }

         _httpClient = httpClient;

         _httpClient.BaseAddress = new Uri(habitRpgConfiguration.ServiceUri, "api/v2/");
         _httpClient.DefaultRequestHeaders.Accept.Clear();
         _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         _httpClient.DefaultRequestHeaders.Add("x-api-user", habitRpgConfiguration.UserId.ToString());
         _httpClient.DefaultRequestHeaders.Add("x-api-key", habitRpgConfiguration.ApiToken.ToString());

         _configuration = habitRpgConfiguration;
      }

      #endregion Constructor

      #region Properties
      public HttpClient HttpClient { get { return _httpClient; } }
      public ILogger Logger { get; set; }

      #endregion

      public T GetResult<T>(HttpResponseMessage response)
      {
         if (Logger != null)
         {
            Logger.Write("URL: {0} Method: {1} StatusCode: {2}", response.RequestMessage.RequestUri, 
               response.RequestMessage.Method, response.StatusCode);
         }

         response.EnsureSuccessStatusCode();

         var contentJson = response.Content.ReadAsStringAsync().Result;

         if (Logger != null)
         {
            Logger.Write("Result: {0} ", contentJson);
         }

         var deserializeObject = JsonConvert.DeserializeObject<T>(contentJson, _configuration.SerializerSettings);

         return deserializeObject;
      }

      public async Task<T> CreateTaskAsync<T>(T task) where T : ITask
      {
         if (task == null)
         {
            throw new ArgumentNullException("task");
         }

         var response = await _httpClient.PostAsJsonAsync("user/tasks", task);

         return GetResult<T>(response);
      }

      public async Task<List<ITask>> GetTasksAsync()
      {
         var response = await _httpClient.GetAsync("user/tasks");

         return GetResult<List<ITask>>(response);
      }

      public async Task<T> GetTaskAsync<T>(string id) where T : ITask
      {
         if (string.IsNullOrWhiteSpace(id))
         {
            throw new ArgumentNullException("id");
         }

         var response = await _httpClient.GetAsync(string.Format("user/tasks/{0}", id));

         return GetResult<T>(response);
      }

      public async Task<User> GetUserAsync()
      {
         var response = await _httpClient.GetAsync("user");

         return GetResult<User>(response);
      }

      public async Task<Member> GetMemberAsync(string id)
      {
         if (string.IsNullOrWhiteSpace(id))
         {
            throw new ArgumentNullException("id");
         }

         var response = await _httpClient.GetAsync(string.Format("members/{0}", id));

         return GetResult<Member>(response);
      }

      public async Task<object> ScoreTaskAsync(string id, Direction direction)
      {
         if (id == null)
         {
            throw new ArgumentNullException("id");
         }

         var response = await _httpClient.PostAsync(string.Format("user/tasks/{0}/{1}", id, direction.ToString().ToLower()), null);

         return GetResult<object>(response);
      }

      public async Task<List<Item>> GetBuyableItemsAsync()
      {
         var response = await _httpClient.GetAsync("user/inventory/buy");

         return GetResult<List<Item>>(response);
      }

      public async Task BuyItemAsync(string key)
      {
         if (key == null)
         {
            throw new ArgumentNullException("key");
         }

         var response = await _httpClient.PostAsync(String.Format("user/inventory/buy/{0}", key), null);

         response.EnsureSuccessStatusCode();
      }

      public async Task<List<Group>> GetGroupsAsync(string types)
      {
         if (types == null)
         {
            throw new ArgumentNullException("types");
         } 
         
         var response = await _httpClient.GetAsync(String.Format("groups?type={0}", types));

         return GetResult<List<Group>>(response);
      }

      public async Task<Group> GetGroupAsync(string groupId)
      {
         if (groupId == null)
         {
            throw new ArgumentNullException("groupId");
         }

         var response = await _httpClient.GetAsync(String.Format("groups/{0}", groupId));

         return GetResult<Group>(response);
      }

      public async Task<List<ChatMessage>> GetGroupChatAsync(string groupId)
      {
         if (groupId == null)
         {
            throw new ArgumentNullException("groupId");
         }

         var response = await _httpClient.GetAsync(String.Format("groups/{0}/chat", groupId));

         return GetResult<List<ChatMessage>>(response);
      }

      public async Task<ChatMessage> PostChatMessageAsync(string groupId, string message)
      {
         if (groupId == null)
         {
            throw new ArgumentNullException("groupId");
         }

         if (message == null)
         {
            throw new ArgumentNullException("message");
         }

         var response = await _httpClient.PostAsync(String.Format("groups/{0}/chat?message={1}", groupId, message), null);

         return GetResult<ChatMessage> (response);
      }

      public async Task SetGroupChatAsSeenAsync()
      {
         await _httpClient.PostAsync(String.Format("groups/{0}/seen"), null);
      }

      public async Task LikeChatMessage(string groupId, string messageId)
      {
         if (groupId == null)
         {
            throw new ArgumentNullException("groupId");
         }

         if (messageId == null)
         {
            throw new ArgumentNullException("messageId");
         }

         await _httpClient.PostAsync(String.Format("groups/{0}/chat/{1}/like", groupId, messageId), null);
      }

      public async Task DeleteChatMessage(string groupId, string messageId)
      {
         if (groupId == null)
         {
            throw new ArgumentNullException("groupId");
         }

         if (messageId == null)
         {
            throw new ArgumentNullException("messageId");
         }

         await _httpClient.DeleteAsync(String.Format("groups/{0}/chat/{1}/like", groupId, messageId));
      }

      public async Task<T> UpdateTaskAsync<T>(T taskObj) where T : ITask
      {
         var response = await _httpClient.PutAsJsonAsync(string.Format("user/tasks/{0}", taskObj.Id), taskObj);

         return GetResult<T>(response);
      }

      public async Task DeleteTaskAsync(string id)
      {
         await _httpClient.DeleteAsync(string.Format("user/tasks/{0}", id));
      }
      
      public async Task<List<ITask>> ClearCompletedAsync()
      {
         var response = await _httpClient.PostAsync("user/tasks/clear-completed", null);

         return GetResult<List<ITask>>(response);
      }

      #region Dispose

      public void Dispose()
      {
         Dispose(true);

         GC.SuppressFinalize(this);
      }

      protected virtual void Dispose(bool disposing)
      {
         if (!_disposed)
         {
            if (disposing)
            {
               // Dispose managed resources.
               _httpClient.Dispose();
            }

            _disposed = true;
         }
      }

      ~HabitRPGClient()
      {
         Dispose(false);
      }

      #endregion Dispose
   }
}