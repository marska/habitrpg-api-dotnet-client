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
  [TestFixture]
  public class UserClientIntegrationTests : IntegrationBase
  {
    private readonly IUserClient _userClient;

    public UserClientIntegrationTests()
    {
      _userClient = new UserClient(HabitRpgConfiguration);
    }

    [Test]
    public void Should_create_new_todo_task()
    {
      // Setup
      var todo = CreateTodo();

      // Action
      var response = _userClient.CreateTaskAsync(todo);
      response.Wait();

      // Verify the result
      AssertTask(todo, response.Result);

      Assert.AreEqual(todo.Completed, response.Result.Completed);
      Assert.AreEqual(todo.Archived, response.Result.Archived);
      Assert.AreEqual(todo.Checklist.First().Id, response.Result.Checklist.First().Id);
      Assert.AreEqual(todo.Checklist.First().Text, response.Result.Checklist.First().Text);
      AssertDateTime(todo.DateCompleted.Value, response.Result.DateCompleted.Value);
      AssertDateTime(todo.Date.Value, response.Result.Date.Value);
      Assert.AreEqual(todo.CollapseChecklist, response.Result.CollapseChecklist);
    }

    [Test]
    public void Should_create_new_habit_task()
    {
      // Setup
      var habit = CreateHabit();

      // Action
      var response = _userClient.CreateTaskAsync(habit);
      response.Wait();

      // Verify the result
      AssertTask(habit, response.Result);

      Assert.AreEqual(habit.Down, response.Result.Down);
      Assert.AreEqual(habit.Up, response.Result.Up);
      Assert.AreEqual(habit.History.First().Date.ToString(CultureInfo.InvariantCulture), response.Result.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(habit.History.First().Value, response.Result.History.First().Value);
    }

    [Test]
    public void Should_create_new_daily_task()
    {
      // Setup
      var daily = CreateDaily();

      // Action
      var response = _userClient.CreateTaskAsync(daily);
      response.Wait();

      // Verify the result
      AssertTask(daily, response.Result);

      Assert.AreEqual(daily.History.First().Date.ToString(CultureInfo.InvariantCulture), response.Result.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(daily.History.First().Value, response.Result.History.First().Value);
      Assert.AreEqual(daily.Completed, response.Result.Completed);
      Assert.AreEqual(daily.Repeat.Friday, response.Result.Repeat.Friday);
      Assert.AreEqual(daily.CollapseChecklist, response.Result.CollapseChecklist);
      Assert.AreEqual(daily.Checklist.First().Id, response.Result.Checklist.First().Id);
      Assert.AreEqual(daily.Checklist.First().Text, response.Result.Checklist.First().Text);
      Assert.AreEqual(daily.Streak, response.Result.Streak);
    }

    [Test]
    public void Should_create_new_reward_task()
    {
      // Setup
      var reward = CreateReward();

      // Action
      var response = _userClient.CreateTaskAsync(reward);
      response.Wait();

      // Verify the result
      AssertTask(reward, response.Result);
    }

    [Test]
    public void Should_create_and_update_todo()
    {
      // Setup
      var todo = CreateTodo();

      // Action
      var response = _userClient.CreateTaskAsync(todo);
      response.Wait();

      AssertTask(todo, response.Result);

      todo.Text = "Some new updated Text";

      response = _userClient.UpdateTaskAsync(todo);
      response.Wait();

      AssertTask(todo, response.Result);
    }

    [Test]
    public void Should_return_all_tasks()
    {
      // Setup
      var habitTask = CreateHabit();
      var task = _userClient.CreateTaskAsync(habitTask);
      task.Wait();

      // Action
      var response = _userClient.GetTasksAsync();
      response.Wait();

      // Verify the result
      Assert.GreaterOrEqual(response.Result.Count, 1);
    }

    [Test]
    public void Should_return_daily_task()
    {
      // Setup
      Daily daily = CreateDaily();
      var task = _userClient.CreateTaskAsync(daily);
      task.Wait();

      // Action
      var response = _userClient.GetTaskAsync<Daily>(daily.Id);
      response.Wait();

      // Verify the result
      AssertTask(daily, response.Result);

      Assert.AreEqual(daily.History.First().Date.ToString(CultureInfo.InvariantCulture), response.Result.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(daily.History.First().Value, response.Result.History.First().Value);
      Assert.AreEqual(daily.Completed, response.Result.Completed);
      Assert.AreEqual(daily.Repeat.Friday, response.Result.Repeat.Friday);
      Assert.AreEqual(daily.CollapseChecklist, response.Result.CollapseChecklist);
      Assert.AreEqual(daily.Checklist.First().Id, response.Result.Checklist.First().Id);
      Assert.AreEqual(daily.Checklist.First().Text, response.Result.Checklist.First().Text);
      Assert.AreEqual(daily.Streak, response.Result.Streak);
    }

    [Test]
    public void Should_score_existing_task()
    {
      // Setup
      var daily = CreateDaily();
      var task = _userClient.CreateTaskAsync(daily);
      task.Wait();

      // Action
      var response = _userClient.ScoreTaskAsync(daily.Id, Direction.Up);
      response.Wait();

      // Verify the result
      Assert.IsNotNull(response.Result);
    }

    [Test]
    public void Should_create_and_score_new_habit_task()
    {
      // Setup
      string text = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

      // Action
      var response = _userClient.ScoreTaskAsync(text, Direction.Up);
      response.Wait();

      // Verify the result
      var tasks = _userClient.GetTasksAsync();
      tasks.Wait();

      bool exist = tasks.Result.Exists(t => t.Text.Equals(text));

      Assert.IsNotNull(response);
      Assert.IsTrue(exist);
    }

    [Test]
    public void Should_get_user()
    {
      // Action
      var response = _userClient.GetUserAsync();
      response.Wait();

      // Verify the result
      Assert.IsNotNull(response.Result);
      Assert.IsNotNull(response.Result.Preferences);
    }

    [Test]
    public void Should_equip_Weapon()
    {
      var response = _userClient.InventoryEquip("equipped", "weapon_warrior_1");
      response.Wait();

      Assert.IsNotEmpty(response.Result.Gear.Equipped);
    }

    [Test]
    public void Should_clear_completed()
    {
      var todo = CreateTodo();

      var createTaskResponse = _userClient.CreateTaskAsync(todo);
      createTaskResponse.Wait();

      var scoreTaskResponse = _userClient.ScoreTaskAsync(todo.Id, Direction.Up);
      scoreTaskResponse.Wait();

      var clearCompletedResponse = _userClient.ClearCompletedAsync();
      clearCompletedResponse.Wait();

      Assert.True(clearCompletedResponse.Result.Any(t => t.Id.Equals(todo.Id)));
    }

    [Test]
    public void Should_get_buyable_items()
    {
      var getBuyableItemsAsyncResponse = _userClient.GetBuyableItemsAsync();
      getBuyableItemsAsyncResponse.Wait();

      Assert.IsNotEmpty(getBuyableItemsAsyncResponse.Result);
    }

    private static void AssertTask(Task expected, Task actual)
    {
      Assert.AreEqual(expected.Type, actual.Type);
      Assert.AreEqual(expected.Id, actual.Id);
      AssertDateTime(expected.DateCreated.Value, actual.DateCreated.Value);
      Assert.AreEqual(expected.Text, actual.Text);
      Assert.AreEqual(expected.Notes, actual.Notes);
      Assert.AreEqual(expected.Tags.First().GetHashCode(), actual.Tags.First().GetHashCode());
      Assert.AreEqual(expected.Value, actual.Value);
      Assert.AreEqual(expected.Priority, actual.Priority);
      Assert.AreEqual(expected.Attribute, actual.Attribute);

      if (expected.Challenge != null)
      {
        Assert.AreEqual(expected.Challenge.Id, actual.Challenge.Id);
      }
    }

    private static void AssertDateTime(DateTime expected, DateTime actual)
    {
      Assert.AreEqual(Math.Abs((expected - actual).TotalSeconds) < 1, true);
    }

    private static Daily CreateDaily()
    {
      var daily = new Daily
      {
        Id = Guid.NewGuid().ToString(),
        DateCreated = DateTime.UtcNow,
        Text = "Main Task: " + DateTime.UtcNow,
        Notes = "Notes",
        Tags = new Dictionary<Guid, bool>
            {
               {Guid.NewGuid(), true}
            },
        Value = 0,
        Priority = Difficulty.Hard,
        Attribute = Attribute.Strength,
        History = new List<History>
            {
               new History { Date = DateTime.UtcNow, Value = 1.5107937890723129d}
            },
        Challenge = new Challenge
        {
          Winner = "User123456",
          Broken = Broken.ChallengeClosed,
          Id = Guid.NewGuid()
        },
        Completed = false,
        Repeat = new Repeat
        {
          Friday = false,
          Wednesday = false
        },
        CollapseChecklist = false,
        Checklist = new List<Checklist>
            {
               new Checklist {Id = Guid.NewGuid(), Text = "Checklist expected 1"}
            },
        Streak = 32.3332
      };

      return daily;
    }

    private static Habit CreateHabit()
    {
      var habitTask = new Habit
      {
        Id = Guid.NewGuid().ToString(),
        DateCreated = DateTime.UtcNow,
        Text = "Main Task: " + DateTime.UtcNow,
        Notes = "Notes",
        Tags = new Dictionary<Guid, bool>
            {
               {Guid.NewGuid(), true}
            },
        Value = 0,
        Priority = Difficulty.Hard,
        Attribute = Attribute.Strength,
        Challenge = new Challenge
        {
          Winner = "User123456",
          Broken = Broken.ChallengeClosed,
          Id = Guid.NewGuid()
        },
        Down = false,
        History = new List<History>
            {
               new History { Date = DateTime.UtcNow, Value = 1.5107937890723129d}
            },
      };

      return habitTask;
    }

    private static Todo CreateTodo()
    {
      var habitTask = new Todo
      {
        Id = Guid.NewGuid().ToString(),
        DateCreated = DateTime.UtcNow,
        Text = "Main Task: " + DateTime.UtcNow,
        Notes = "Notes",
        Tags = new Dictionary<Guid, bool>
            {
               {Guid.NewGuid(), true}
            },
        Value = 0,
        Priority = Difficulty.Hard,
        Attribute = Attribute.Strength,
        Challenge = new Challenge
        {
          Winner = "User123456",
          Broken = Broken.ChallengeClosed,
          Id = Guid.NewGuid()
        },
        Checklist = new List<Checklist>
            {
               new Checklist {Id = Guid.NewGuid(), Text = "Checklist expected 1"}
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
      var reward = new Reward
      {
        Id = Guid.NewGuid().ToString(),
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
        Challenge = new Challenge
        {
          Winner = "User123456",
          Broken = Broken.ChallengeClosed,
          Id = Guid.NewGuid()
        }
      };

      return reward;
    }
  }
}