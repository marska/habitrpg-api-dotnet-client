using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using HabitRPG.Client.Model;

namespace HabitRPG.Client.Common
{
  public class ClientBase : IDisposable
  {
    private bool _disposed;

    private readonly HabitRpgConfiguration _configuration;

    protected HttpClient HttpClient { get; private set; }

    public ClientBase(HabitRpgConfiguration habitRpgConfiguration)
      : this(habitRpgConfiguration, new HttpClient(new HttpClientHandler()))
    {
    }

    public ClientBase(HabitRpgConfiguration habitRpgConfiguration, IWebProxy httpClient)
      : this(habitRpgConfiguration, new HttpClientHandler { Proxy = httpClient, UseProxy = true })
    {
    }

    public ClientBase(HabitRpgConfiguration habitRpgConfiguration, HttpClientHandler httpClientHandler)
      : this(habitRpgConfiguration, new HttpClient(httpClientHandler))
    {
    }

    public ClientBase(Guid userId, Guid apiToken, Uri serviceUri)
      : this(new HabitRpgConfiguration { ApiToken = apiToken, ServiceUri = serviceUri, UserId = userId }, new HttpClient())
    {
    }

    public ClientBase(HabitRpgConfiguration habitRpgConfiguration, HttpClient httpClient)
    {
      if (habitRpgConfiguration == null)
      {
        throw new ArgumentNullException("habitRpgConfiguration");
      }

      if (httpClient == null)
      {
        throw new ArgumentNullException("httpClient");
      }

      HttpClient = httpClient;

      HttpClient.BaseAddress = new Uri(habitRpgConfiguration.ServiceUri, "api/v3/");
      HttpClient.DefaultRequestHeaders.Accept.Clear();
      HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
      HttpClient.DefaultRequestHeaders.Add("x-api-user", habitRpgConfiguration.UserId.ToString());
      HttpClient.DefaultRequestHeaders.Add("x-api-key", habitRpgConfiguration.ApiToken.ToString());

      _configuration = habitRpgConfiguration;
    }

    public ILogger Logger { get; set; }

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

      var deserializeObject = JsonConvert.DeserializeObject<ApiResponse<T>>(contentJson, _configuration.SerializerSettings);

      return deserializeObject.Data;
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
          HttpClient.Dispose();
        }

        _disposed = true;
      }
    }

    ~ClientBase()
    {
      Dispose(false);
    }

    #endregion Dispose
  }
}
