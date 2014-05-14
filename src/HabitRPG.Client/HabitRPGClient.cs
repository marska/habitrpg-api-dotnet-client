using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

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

    public async Task<Model.Todo> CreateTodo(Model.Todo task)
    {
      using (var client = new HttpClient())
      {
        client.BaseAddress = _habitRpgConfiguration.ServiceUri;
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("x-api-user", _habitRpgConfiguration.UserId.ToString());
        client.DefaultRequestHeaders.Add("x-api-key", _habitRpgConfiguration.ApiToken.ToString());

        try
        {
          var response = await client.PostAsJsonAsync("api/v2/user/tasks", task);

          response.EnsureSuccessStatusCode();

          var responseContent = response.Content.ReadAsAsync<Model.Todo>();

          return responseContent.Result;
        }
        catch (HttpRequestException e)
        {
          //todo: catch exceptions
          Console.WriteLine(e.Message);
          throw;
        }
      }
    }
  }
}