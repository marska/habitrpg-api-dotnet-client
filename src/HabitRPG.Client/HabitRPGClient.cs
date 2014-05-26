using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Task = HabitRPG.Client.Model.Task;

namespace HabitRPG.Client
{
  public class HabitRPGClient : IHabitRPGClient
  {
    private readonly HabitRpgConfiguration _habitRpgConfiguration;

    public HabitRPGClient(HabitRpgConfiguration habitRpgConfiguration)
    {
      if (habitRpgConfiguration == null)
      {
        throw new ArgumentNullException("habitRpgConfiguration");
      }

      _habitRpgConfiguration = habitRpgConfiguration;
    }

    public async Task<T> CreateTask<T>(T task) where T : Task
    {
      if (task == null)
      {
        throw new ArgumentNullException("task");
      }

      var clientHandler = new HttpClientHandler
      {
        Proxy = _habitRpgConfiguration.Proxy
      };

      using (var client = new HttpClient(clientHandler))
      {
        client.BaseAddress = _habitRpgConfiguration.ServiceUri;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-user", _habitRpgConfiguration.UserId.ToString());
        client.DefaultRequestHeaders.Add("x-api-key", _habitRpgConfiguration.ApiToken.ToString());

        var response = await client.PostAsJsonAsync("api/v2/user/tasks", task);

        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsAsync<T>();

        return responseContent.Result;
      }
    }

    public async Task<List<Task>> GetTasks()
    {
      var clientHandler = new HttpClientHandler
      {
        Proxy = _habitRpgConfiguration.Proxy
      };

      using (var client = new HttpClient(clientHandler))
      {
        client.BaseAddress = _habitRpgConfiguration.ServiceUri;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-user", _habitRpgConfiguration.UserId.ToString());
        client.DefaultRequestHeaders.Add("x-api-key", _habitRpgConfiguration.ApiToken.ToString());

        HttpResponseMessage response = await client.GetAsync("api/v2/user/tasks");

        response.EnsureSuccessStatusCode();

        Task<List<Task>> responseContent = response.Content.ReadAsAsync<List<Task>>();

        return responseContent.Result;
      }
    }

    public async Task<T> GetTask<T>(string id) where T : Task
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        throw new ArgumentNullException("id");
      }

      var clientHandler = new HttpClientHandler
      {
        Proxy = _habitRpgConfiguration.Proxy
      };

      using (var client = new HttpClient(clientHandler))
      {
        client.BaseAddress = _habitRpgConfiguration.ServiceUri;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-user", _habitRpgConfiguration.UserId.ToString());
        client.DefaultRequestHeaders.Add("x-api-key", _habitRpgConfiguration.ApiToken.ToString());

        HttpResponseMessage response = await client.GetAsync(string.Format("api/v2/user/tasks/{0}", id));
        
        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsAsync<T>();

        return responseContent.Result;
      }
    }

    public async Task<object> ScoreTask(string id, string direction)
    {
      if (id == null)
      {
        throw new ArgumentNullException("id");
      }

      if (direction == null)
      {
        throw new ArgumentNullException("direction");
      }

      var clientHandler = new HttpClientHandler
      {
        Proxy = _habitRpgConfiguration.Proxy
      };

      using (var client = new HttpClient(clientHandler))
      {
        client.BaseAddress = _habitRpgConfiguration.ServiceUri;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-user", _habitRpgConfiguration.UserId.ToString());
        client.DefaultRequestHeaders.Add("x-api-key", _habitRpgConfiguration.ApiToken.ToString());

        var response = await client.PostAsync(string.Format("api/v2/user/tasks/{0}/{1}", id, direction), null);

        response.EnsureSuccessStatusCode();

        var responseContent = response.Content.ReadAsAsync<object>();

        return responseContent.Result;
      }
    }
  }
}