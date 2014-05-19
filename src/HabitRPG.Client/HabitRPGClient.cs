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
      using (var client = new HttpClient())
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
      using (var client = new HttpClient())
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
  }
}