using System;
using NUnit.Framework;

namespace HabitRPG.Client.Test
{
  [TestFixture]
  public class IntegrationBase
  {
    private readonly IUserClient _userClient;

    public IntegrationBase()
    {
      HabitRpgConfiguration = new HabitRpgConfiguration
      {
        UserId = Guid.Parse("33b8cd45-0434-4a9a-943a-a90021affdc8"),
        ApiToken = Guid.Parse("f9cf8c3c-057a-430e-a4ed-fb4c597a32cb"),
        ServiceUri = new Uri(@"https://habitrpg.com/")
      };

      _userClient = new UserClient(HabitRpgConfiguration);
    }

    public HabitRpgConfiguration HabitRpgConfiguration { get; set; }

    [TearDown]
    public void TearDown()
    {
      var response = _userClient.GetTasksAsync();
      response.Wait();

      var tasks = response.Result;
      if (tasks.Count > 0)
      {
        tasks.ForEach(t =>
        {
          var deleteTaskAsync = _userClient.DeleteTaskAsync(t.Id);
          deleteTaskAsync.Wait();
        });
      }
    }
  }
}
