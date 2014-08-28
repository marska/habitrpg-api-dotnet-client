using System.Threading.Tasks;
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
  public class HabitRPGClientIntegrationTests
  {
    private readonly IHabitRPGClient _habitRpgService;

    public HabitRPGClientIntegrationTests()
    {
      var configuration = new HabitRpgConfiguration
      {
        UserId = Guid.Parse("55a4a342-c8da-4c95-9467-4a304a4ae4bd"),
        ApiToken = Guid.Parse("4a64e99a-de87-4fcc-a8bf-aee21dd59a8c"),
        ServiceUri = new Uri(@"https://habitrpg.com/")
      };

      _habitRpgService = new HabitRPGClient(configuration);
    }
    
    [TestFixtureTearDown]
    public async void Dispose()
    {
      var response = await _habitRpgService.GetTasksAsync();

      if (response.Count > 0)
      {
        foreach (var task in response)
        {
          await _habitRpgService.DeleteTaskAsync(task.Id);  
        }
      }
    }

    [Test]
    public async void Should_create_new_todo_task()
    {
      // Setup
      var todo = CreateTodo();

      // Action
      var response = await _habitRpgService.CreateTaskAsync(todo);

      // Verify the result
      AssertTask(todo, response);

      Assert.AreEqual(todo.Completed, response.Completed);
      Assert.AreEqual(todo.Archived, response.Archived);
      Assert.AreEqual(todo.Checklist.First().Id, response.Checklist.First().Id);
      Assert.AreEqual(todo.Checklist.First().Text, response.Checklist.First().Text);
      AssertDateTime(todo.DateCompleted.Value, response.DateCompleted.Value);
      AssertDateTime(todo.Date.Value, response.Date.Value);
      Assert.AreEqual(todo.CollapseChecklist, response.CollapseChecklist);
    }

    [Test]
    public async void Should_create_new_habit_task()
    {
      // Setup
      var habit = CreateHabit();

      // Action
      var response = await _habitRpgService.CreateTaskAsync(habit);

      // Verify the result
      AssertTask(habit, response);

      Assert.AreEqual(habit.Down, response.Down);
      Assert.AreEqual(habit.Up, response.Up);
      Assert.AreEqual(habit.History.First().Date.ToString(CultureInfo.InvariantCulture), response.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(habit.History.First().Value, response.History.First().Value);
    }

    [Test]
    public async void Should_create_new_daily_task()
    {
      // Setup
      var daily = CreateDaily();

      // Action
      var response = await _habitRpgService.CreateTaskAsync(daily);

      // Verify the result
      AssertTask(daily, response);

      Assert.AreEqual(daily.History.First().Date.ToString(CultureInfo.InvariantCulture), response.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(daily.History.First().Value, response.History.First().Value);
      Assert.AreEqual(daily.Completed, response.Completed);
      Assert.AreEqual(daily.Repeat.Friday, response.Repeat.Friday);
      Assert.AreEqual(daily.CollapseChecklist, response.CollapseChecklist);
      Assert.AreEqual(daily.Checklist.First().Id, response.Checklist.First().Id);
      Assert.AreEqual(daily.Checklist.First().Text, response.Checklist.First().Text);
      Assert.AreEqual(daily.Streak, response.Streak);
    }

    [Test]
    public async void Should_create_new_reward_task()
    {
      // Setup
      var reward = CreateReward();

      // Action
      var response = await _habitRpgService.CreateTaskAsync(reward);

      // Verify the result
      AssertTask(reward, response);
    }

    [Test]
    public async void Should_create_and_update_todo()
    {
      // Setup
      var todo = CreateTodo();

      // Action
      var response = await _habitRpgService.CreateTaskAsync(todo);

      AssertTask(todo, response);

      todo.Text = "Some new updated Text";

      response = await _habitRpgService.UpdateTaskAsync(todo);

      AssertTask(todo, response);
    }

    [Test]
    public async void Should_return_all_tasks()
    {
      // Setup
      var habitTask = CreateHabit();
      await _habitRpgService.CreateTaskAsync(habitTask);

      // Action
      var response = await _habitRpgService.GetTasksAsync();

      // Verify the result
      Assert.GreaterOrEqual(response.Count, 1);
    }

    [Test]
    public async void Should_return_daily_task_and_delete_it()
    {
      // Setup
      Daily daily = CreateDaily();
      await _habitRpgService.CreateTaskAsync(daily);

      // Action
      Daily response = await _habitRpgService.GetTaskAsync<Daily>(daily.Id);

      // Verify the result
      AssertTask(daily, response);

      Assert.AreEqual(daily.History.First().Date.ToString(CultureInfo.InvariantCulture), response.History.First().Date.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(daily.History.First().Value, response.History.First().Value);
      Assert.AreEqual(daily.Completed, response.Completed);
      Assert.AreEqual(daily.Repeat.Friday, response.Repeat.Friday);
      Assert.AreEqual(daily.CollapseChecklist, response.CollapseChecklist);
      Assert.AreEqual(daily.Checklist.First().Id, response.Checklist.First().Id);
      Assert.AreEqual(daily.Checklist.First().Text, response.Checklist.First().Text);
      Assert.AreEqual(daily.Streak, response.Streak);

      await _habitRpgService.DeleteTaskAsync(daily.Id);
    }

    [Test]
    public async void Should_score_existing_task()
    {
      // Setup
      Daily daily = CreateDaily();
      await _habitRpgService.CreateTaskAsync(daily);

      // Action
      var response = await _habitRpgService.ScoreTaskAsync(daily.Id.ToString(), Direction.Up);

      Assert.IsNotNull(response);
    }

    [Test]
    public async void Should_create_and_score_new_habit_task()
    {
      // Setup
      string text = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

      // Action
      object response = await _habitRpgService.ScoreTaskAsync(text, Direction.Up);

      // Verify the result
      var tasks = await _habitRpgService.GetTasksAsync();
      bool exist = tasks.Exists(t => t.Text.Equals(text));

      Assert.IsNotNull(response);
      Assert.IsTrue(exist);
    }

    [Test]
    public async void Should_get_user()
    {
      var user = await _habitRpgService.GetUserAsync();

      Assert.IsNotNull(user);
      Assert.IsNotNull(user.Preferences);
    }

    [Test]
    public async void Should_get_member()
    {
      var member = await _habitRpgService.GetMemberAsync("55a4a342-c8da-4c95-9467-4a304a4ae4bd");

      Assert.IsNotNull(member);
      Assert.IsNotNull(member.Preferences);
    }

    [Test]
    public async void Should_clear_completed()
    {
      var todo = CreateTodo();

      await _habitRpgService.CreateTaskAsync<Todo>(todo);

      var response = await _habitRpgService.ScoreTaskAsync(todo.Id, Direction.Up);

      var clearedTasks = await _habitRpgService.ClearCompletedAsync();

      Assert.True(clearedTasks.Any(t => t.Id.Equals(todo.Id)));
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
      var reward = new Reward()
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
        Challenge = new Challenge()
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