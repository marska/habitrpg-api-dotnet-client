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
      var todo = CreateTodo();

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

    [Test]
    public async void Should_Create_New_Habit_Task()
    {
      // Setup
      var habit = CreateHabit();

      // Action
      var response = await _habitRpgService.CreateTask(habit);

      // Verify the result
      Assert.AreEqual(habit.Type, response.Type);
      Assert.AreEqual(habit.Id, response.Id);
      Assert.AreEqual(habit.DateCreated, response.DateCreated);
      Assert.AreEqual(habit.Text, response.Text);
      Assert.AreEqual(habit.Notes, response.Notes);
      Assert.AreEqual(habit.Tags.Any().GetHashCode(), response.Tags.Any().GetHashCode());
      Assert.AreEqual(habit.Value, response.Value);
      Assert.AreEqual(habit.Priority, response.Priority);
      Assert.AreEqual(habit.Attribute, response.Attribute);
      Assert.AreEqual(habit.Challenge.Any().GetHashCode(), response.Challenge.Any().GetHashCode());

      Assert.AreEqual(habit.Down, response.Down);
      Assert.AreEqual(habit.Up, response.Up);
      Assert.AreEqual(habit.History.Any().GetHashCode(), response.History.Any().GetHashCode());
    }

    [Test]
    public async void Should_Create_New_Daily_Task()
    {
      // Setup
      var daily = CreateDaily();

      // Action
      var response = await _habitRpgService.CreateTask(daily);

      // Verify the result
      Assert.AreEqual(daily.Type, response.Type);
      Assert.AreEqual(daily.Id, response.Id);
      Assert.AreEqual(daily.DateCreated, response.DateCreated);
      Assert.AreEqual(daily.Text, response.Text);
      Assert.AreEqual(daily.Notes, response.Notes);
      Assert.AreEqual(daily.Tags.Any().GetHashCode(), response.Tags.Any().GetHashCode());
      Assert.AreEqual(daily.Value, response.Value);
      Assert.AreEqual(daily.Priority, response.Priority);
      Assert.AreEqual(daily.Attribute, response.Attribute);
      Assert.AreEqual(daily.Challenge.Any().GetHashCode(), response.Challenge.Any().GetHashCode());

      Assert.AreEqual(daily.History.Any().GetHashCode(), response.History.Any().GetHashCode());
      Assert.AreEqual(daily.Completed, response.Completed);
      Assert.AreEqual(daily.Repeat.Friday, response.Repeat.Friday);
      Assert.AreEqual(daily.CollapseChecklist, response.CollapseChecklist);
      Assert.AreEqual(daily.Checklist.Any().GetHashCode(), response.Checklist.Any().GetHashCode());
      Assert.AreEqual(daily.Streak, response.Streak);
    }

    [Test]
    public async void Should_Create_New_Reward_Task()
    {
      // Setup
      var reward = CreateReward();

      // Action
      var response = await _habitRpgService.CreateTask(reward);

      // Verify the result
      Assert.AreEqual(reward.Type, response.Type);
      Assert.AreEqual(reward.Id, response.Id);
      Assert.AreEqual(reward.DateCreated, response.DateCreated);
      Assert.AreEqual(reward.Text, response.Text);
      Assert.AreEqual(reward.Notes, response.Notes);
      Assert.AreEqual(reward.Tags.Any().GetHashCode(), response.Tags.Any().GetHashCode());
      Assert.AreEqual(reward.Value, response.Value);
      Assert.AreEqual(reward.Priority, response.Priority);
      Assert.AreEqual(reward.Attribute, response.Attribute);
      Assert.AreEqual(reward.Challenge.Any().GetHashCode(), response.Challenge.Any().GetHashCode());
    }

    [Test]
    public async void Should_Return_All_Tasks()
    {
      // Setup
      var habitTask = CreateHabit();
      await _habitRpgService.CreateTask(habitTask);

      // Action
      List<Task> response = await _habitRpgService.GetTasks();

      // Verify the result
      Assert.GreaterOrEqual(response.Count, 1);
    }

    private static Daily CreateDaily()
    {
      var daily = new Daily()
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
                History = new Dictionary<DateTime, double>()
        {
          {new DateTime(), 28.1123 }
        },

        Completed = false,
        Repeat = new Repeat() { Friday = false, Wednesday = false },
        CollapseChecklist = false,
        Checklist = new List<Checklist>
        {
          new Checklist {Id = Guid.NewGuid(), Text = "Checklist task 1"}
        },
        Streak = 32.3332
      };

      return daily;
    }

    private static Habit CreateHabit()
    {
      var habitTask = new Habit()
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
        Down = false,
        History = new Dictionary<DateTime, double>()
        {
          {new DateTime(), 28.1123 }
        }
      };

      return habitTask;
    }

    private static Todo CreateTodo()
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

    private static Reward CreateReward()
    {
      var reward = new Reward()
      {
        Id = Guid.NewGuid(),
        DateCreated = DateTime.Now,
        Text = "Main Task: " + DateTime.Now,
        Notes = "Notes",
        Tags = new Dictionary<Guid, bool>
        {
          {Guid.NewGuid(), true}
        },
        Value = 1110,
        Priority = Difficulty.Hard,
        Attribute = Attribute.Strength,
        Challenge = new List<Challenge>()
        {
          new Challenge() {Winner = "User123456", Broken = Broken.ChallengeClosed, Id = Guid.NewGuid()}
        }
      };

      return reward;
    }
  }
}