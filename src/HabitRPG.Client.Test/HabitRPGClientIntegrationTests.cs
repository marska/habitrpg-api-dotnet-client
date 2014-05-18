using System;
using System.Collections.Generic;
using System.Linq;
using HabitRPG.Client.Model;
using NUnit.Framework;
using Attribute = HabitRPG.Client.Model.Attribute;

namespace HabitRPG.Client.Test
{
  [TestFixture]
  public class HabitRPGClientIntegrationTests
  {
    private readonly IHabitRPGClient _habitRpgService;
    public HabitRPGClientIntegrationTests()
    {
      var configuration = new HabitRpgConfiguration()
      {
        UserId = Guid.Parse("55a4a342-c8da-4c95-9467-4a304a4ae4bd"),
        ApiToken = Guid.Parse("4a64e99a-de87-4fcc-a8bf-aee21dd59a8c"),
        ServiceUri = new Uri(@"https://habitrpg.com/")
      };

      _habitRpgService = new HabitRPGClient(configuration);
    }

    [Test]
    public async void Should_Create_New_Todo_Task()
    {
      // Setup
      var todo = GetHabitTodo();

      // Action
      var response = await _habitRpgService.CreateTask(todo);

      // Verify the result
      Assert.AreEqual(todo.Type, response.Type);
      Assert.AreEqual(todo.Id, response.Id);
      Assert.AreEqual(todo.DateCreated, response.DateCreated);
      Assert.AreEqual(todo.Text, response.Text);
      Assert.AreEqual(todo.Notes, response.Notes);
      Assert.AreEqual(todo.Tags.Any().GetHashCode(), response.Tags.Any().GetHashCode());
      Assert.AreEqual(todo.Value, response.Value);
      Assert.AreEqual(todo.Priority, response.Priority);
      Assert.AreEqual(todo.Attribute, response.Attribute);
      Assert.AreEqual(todo.Challenge.Any().GetHashCode(), response.Challenge.Any().GetHashCode());

      Assert.AreEqual(todo.Completed, response.Completed);
      Assert.AreEqual(todo.Archived, response.Archived);
      Assert.AreEqual(todo.Checklist.Any().GetHashCode(), response.Checklist.Any().GetHashCode());
      Assert.AreEqual(todo.DateCompleted, response.DateCompleted);
      Assert.AreEqual(todo.Date, response.Date);
      Assert.AreEqual(todo.CollapseChecklist, response.CollapseChecklist);
    }

    private static Todo GetHabitTodo()
    {
      var habitTask = new Todo
      {
        Id = Guid.NewGuid(),
        DateCreated = DateTime.Now,
        Text = "Main Task: " + DateTime.Now,
        Notes = "Notes",
        Tags = new Dictionary<Guid, bool>
        {
          {Guid.NewGuid(), true}
        },
        Value = 0,
        Priority = Difficulty.Hard,
        Attribute = Attribute.Strength,
        Challenge = new List<Challenge>()
        {
          new Challenge() {Winner = "User123456", Broken = Broken.ChallengeClosed, Id = Guid.NewGuid()}
        },
        Checklist = new List<Checklist>
        {
          new Checklist {Id = Guid.NewGuid(), Text = "Checklist task 1"}
        },
        Completed = true,
        Archived = true,
        DateCompleted = DateTime.Now,
        Date = DateTime.Now,
        CollapseChecklist = true
      };

      return habitTask;
    }
  }
}