using NUnit.Framework;

namespace HabitRPG.Client.Test
{
  [TestFixture]
  public class MembersClientIntegrationTests : IntegrationBase
  {
    private readonly IMembersClient _membersClient;

    public MembersClientIntegrationTests()
    {
      _membersClient = new MembersClient(HabitRpgConfiguration);
    }

    [Test]
    public void Should_get_member()
    {
      // Action
      var response = _membersClient.GetMemberAsync("55a4a342-c8da-4c95-9467-4a304a4ae4bd");
      response.Wait();

      // Verify the result
      Assert.IsNotNull(response.Result);
      Assert.IsNotNull(response.Result.Preferences);
    }
  }
}
