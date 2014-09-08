using HabitRPG.Client.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Attribute = HabitRPG.Client.Model.Attribute;
using Task = HabitRPG.Client.Model.Task;

namespace HabitRPG.Client.Test
{
  public class GroupsClientIntegrationTests : IntegrationBase
  {
     private readonly IGroupsClient _membersClient;

     public GroupsClientIntegrationTests()
    {
      _membersClient = new GroupsClient(HabitRpgConfiguration);
    }

    [Test]
    public void Should_get_group_tavern()
    {
      var getGroupAsyncResponse = _membersClient.GetGroupAsync("habitrpg");
      getGroupAsyncResponse.Wait();

      Assert.IsNotNull(getGroupAsyncResponse.Result);
      Assert.IsNotNull(getGroupAsyncResponse.Result.Id);
      Assert.IsNotEmpty(getGroupAsyncResponse.Result.Chat);
    }

    [Test]
    public void Should_get_tavern_chat()
    {
      var getGroupChatAsyncResponse = _membersClient.GetGroupChatAsync("habitrpg");
      getGroupChatAsyncResponse.Wait();

      Assert.IsNotEmpty(getGroupChatAsyncResponse.Result);
    }

  }
}
