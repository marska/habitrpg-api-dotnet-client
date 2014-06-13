using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Task = HabitRPG.Client.Model.Task;

namespace HabitRPG.Client
{
  public class HabitRPGClient : IHabitRPGClient, IDisposable
  {
    private readonly HttpClient _httpClient;

    private bool _disposed;

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

      _httpClient.BaseAddress = habitRpgConfiguration.ServiceUri;
      _httpClient.DefaultRequestHeaders.Accept.Clear();
      _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      _httpClient.DefaultRequestHeaders.Add("x-api-user", habitRpgConfiguration.UserId.ToString());
      _httpClient.DefaultRequestHeaders.Add("x-api-key", habitRpgConfiguration.ApiToken.ToString());
    }

    public async Task<T> CreateTask<T>(T task) where T : Task
    {
      if (task == null)
      {
        throw new ArgumentNullException("task");
      }

      var response = await _httpClient.PostAsJsonAsync("api/v2/user/tasks", task);

      return GetResult<T>(response);
    }

    public async Task<List<Task>> GetTasks()
    {
      var response = await _httpClient.GetAsync("api/v2/user/tasks");

      return GetResult<List<Task>>(response);
    }

    public async Task<T> GetTask<T>(string id) where T : Task
    {
      if (string.IsNullOrWhiteSpace(id))
      {
        throw new ArgumentNullException("id");
      }

      var response = await _httpClient.GetAsync(string.Format("api/v2/user/tasks/{0}", id));

      return GetResult<T>(response);
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

      var response = await _httpClient.PostAsync(string.Format("api/v2/user/tasks/{0}/{1}", id, direction), null);

      return GetResult<object>(response);
    }

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

    private static T GetResult<T>(HttpResponseMessage response)
    {
      response.EnsureSuccessStatusCode();
      var responseContent = response.Content.ReadAsAsync<T>();
      return responseContent.Result;
    }

    ~HabitRPGClient()
    {
      Dispose(false);
    }

  }
}