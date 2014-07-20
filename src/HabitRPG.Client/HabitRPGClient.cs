using HabitRPG.Client.Extensions;
using HabitRPG.Client.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HabitRPG.Client
{
   public class HabitRPGClient : IHabitRPGClient, IDisposable
   {
      private readonly HttpClient _httpClient;

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
      }

      #endregion Constructor

      public async Task<T> CreateTaskAsync<T>(T task) where T : ITask
      {
         if (task == null)
         {
            throw new ArgumentNullException("task");
         }

         var response = await _httpClient.PostAsJsonAsync("user/tasks", task);

         return GetResult<T>(response);
      }

      public async Task<List<Model.ITask>> GetTasksAsync()
      {
         var response = await _httpClient.GetAsync("user/tasks");

         return GetResult<List<Model.ITask>>(response);
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

      public async Task<Model.User> GetUser()
      {
         var response = await _httpClient.GetAsync("user");

         var responseString = await response.Content.ReadAsStringAsync();

         return GetResult<Model.User>(response);
      }

      public async Task<object> ScoreTaskAsync(string id, string direction)
      {
         if (id == null)
         {
            throw new ArgumentNullException("id");
         }

         if (direction == null)
         {
            throw new ArgumentNullException("direction");
         }

         var response = await _httpClient.PostAsync(string.Format("user/tasks/{0}/{1}", id, direction), null);

         return GetResult<object>(response);
      }

      public async Task<T> UpdateTaskAsync<T>(T taskObj) where T : ITask
      {
         var response = await _httpClient.PutAsJsonAsync(string.Format("user/tasks/{0}", taskObj.Id), taskObj);

         return GetResult<T>(response);
      }

      public async System.Threading.Tasks.Task DeleteTaskAsync(string id)
      {
         var response = await _httpClient.DeleteAsync(string.Format("user/tasks/{0}", id));

         var responseString = await response.Content.ReadAsStringAsync();

         return;
      }
      
      public async Task<List<ITask>> ClearCompletedAsync()
      {
         var response = await _httpClient.PostAsync("user/tasks/clear-completed", null);

         return GetResult<List<Model.ITask>>(response);
      }

      private static T GetResult<T>(HttpResponseMessage response)
      {
         response.EnsureSuccessStatusCode();
         var responseContent = response.Content.ReadAsAsync<T>();
         return responseContent.Result;
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