using HabitRPG.Client.Common;
using HabitRPG.Client.Extensions;
using HabitRPG.Client.Model;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
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

      var response = await HttpClient.PostAsJsonAsync("tasks/user", task);

      return GetResult<T>(response);
    }

    //DONEV3
    public async Task<List<ITask>> GetTasksAsync()
    {
      var response = await HttpClient.GetAsync("tasks/user");

      return GetResult<List<ITask>>(response);
    }

    public async Task<T> GetTaskAsync<T>(string id) where T : ITask
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        throw new ArgumentNullException("id");
      }

      var response = await HttpClient.GetAsync(string.Format("tasks/{0}", id));

      return GetResult<T>(response);
    }

    public async Task<Items> InventoryEquip(string type, string key)
    {
      if (type == null)
      {
        throw new ArgumentNullException("type");
      }

      if (key == null)
      {
        throw new ArgumentNullException("key");
      }

      var response = await HttpClient.PostAsync(String.Format("user/equip/{0}/{1}", type, key), null);

      response.EnsureSuccessStatusCode();

      return GetResult<Items>(response);
    }

    public async Task<User> GetUserAsync()
    {
      var response = await HttpClient.GetAsync("user");

      return GetResult<User>(response);
    }

    public async Task CreateTagAsync(Tag tag)
    {
      var response = await HttpClient.PostAsJsonAsync("tags", tag);

      response.EnsureSuccessStatusCode();
    }

    public async Task UpdateTagAsync(Tag tag)
    {
      var response = await HttpClient.PutAsJsonAsync(String.Format("tags/{0}", tag.Id), tag);

      response.EnsureSuccessStatusCode();
    }

    public async Task DeleteTagAsync(string tagId)
    {
      if (tagId == null)
      {
        throw new ArgumentNullException("tagId");
      }

      var response = await HttpClient.DeleteAsync(String.Format("tags/{0}", tagId));

      response.EnsureSuccessStatusCode();
    }

    public async Task<ScoreResult> ScoreTaskAsync(string id, Direction direction)
    {
      if (id == null)
      {
        throw new ArgumentNullException("id");
      }

      var response = await HttpClient.PostAsync(string.Format("tasks/{0}/score/{1}", id, direction.ToString().ToLower()), null);

      return GetResult<ScoreResult>(response);
    }

    public async Task<List<Item>> GetBuyableItemsAsync()
    {
      var response = await HttpClient.GetAsync("user/inventory/buy");

      return GetResult<List<Item>>(response);
    }

    // TODO: Need to expand to fix this to accommodate all purchases
    public async Task BuyItemAsync(string key)
    {
      if (key == null)
      {
        throw new ArgumentNullException("key");
      }

      var response = await HttpClient.PostAsync(String.Format("user/inventory/buy/{0}", key), null);

      response.EnsureSuccessStatusCode();
    }

    // TODO: Need to fix this to include group ID
    public async Task SetGroupChatAsSeenAsync()
    {
      await HttpClient.PostAsync(String.Format("groups/{0}/chat/seen"), null);
    }

    public async Task<T> UpdateTaskAsync<T>(T taskObj) where T : ITask
    {
      var response = await HttpClient.PutAsJsonAsync(string.Format("tasks/{0}", taskObj.Id), taskObj);

      return GetResult<T>(response);
    }

    public async Task DeleteTaskAsync(string id)
    {
      await HttpClient.DeleteAsync(string.Format("tasks/{0}", id));
    }

    public async Task<List<ITask>> ClearCompletedAsync()
    {
      var response = await HttpClient.PostAsync("tasks/clearCompletedTodos", null);
      // TODO: Return something?
      return GetResult<List<ITask>>(response);
    }
  }
}