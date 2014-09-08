using HabitRPG.Client.Common;
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
  public class UserClient : ClientBase, IUserClient
  {
    public UserClient(HabitRpgConfiguration habitRpgConfiguration) : base(habitRpgConfiguration)
    {
    }

    public UserClient(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient) : base(habitRpgConfiguration, httpClient)
    {
    }

    public UserClient(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler) : base(habitRpgConfiguration, httpClientHandler)
    {
    }

    public UserClient(Guid userId, Guid apiToken, Uri serviceUri) : base(userId, apiToken, serviceUri)
    {
    }

    public UserClient(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient) : base(habitRpgConfiguration, httpClient)
    {
    }

    public async Task<T> CreateTaskAsync<T>(T task) where T : ITask
    {
      if (task == null)
      {
        throw new ArgumentNullException("task");
      }

      var response = await HttpClient.PostAsJsonAsync("user/tasks", task);

      return GetResult<T>(response);
    }

    public async Task<List<ITask>> GetTasksAsync()
    {
      var response = await HttpClient.GetAsync("user/tasks");

      return GetResult<List<ITask>>(response);
    }

    public async Task<T> GetTaskAsync<T>(string id) where T : ITask
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        throw new ArgumentNullException("id");
      }

      var response = await HttpClient.GetAsync(string.Format("user/tasks/{0}", id));

      return GetResult<T>(response);
    }

    public async Task<User> GetUserAsync()
    {
      var response = await HttpClient.GetAsync("user");

      return GetResult<User>(response);
    }

    public async Task<object> ScoreTaskAsync(string id, Direction direction)
    {
      if (id == null)
      {
        throw new ArgumentNullException("id");
      }

      var response = await HttpClient.PostAsync(string.Format("user/tasks/{0}/{1}", id, direction.ToString().ToLower()), null);

      return GetResult<object>(response);
    }

    public async Task<List<Item>> GetBuyableItemsAsync()
    {
      var response = await HttpClient.GetAsync("user/inventory/buy");

      return GetResult<List<Item>>(response);
    }

    public async Task BuyItemAsync(string key)
    {
      if (key == null)
      {
        throw new ArgumentNullException("key");
      }

      var response = await HttpClient.PostAsync(String.Format("user/inventory/buy/{0}", key), null);

      response.EnsureSuccessStatusCode();
    }

    public async Task SetGroupChatAsSeenAsync()
    {
      await HttpClient.PostAsync(String.Format("groups/{0}/seen"), null);
    }

    public async Task<T> UpdateTaskAsync<T>(T taskObj) where T : ITask
    {
      var response = await HttpClient.PutAsJsonAsync(string.Format("user/tasks/{0}", taskObj.Id), taskObj);

      return GetResult<T>(response);
    }

    public async Task DeleteTaskAsync(string id)
    {
      await HttpClient.DeleteAsync(string.Format("user/tasks/{0}", id));
    }

    public async Task<List<ITask>> ClearCompletedAsync()
    {
      var response = await HttpClient.PostAsync("user/tasks/clear-completed", null);

      return GetResult<List<ITask>>(response);
    }
  }
}