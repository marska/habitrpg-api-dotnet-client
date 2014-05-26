using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using HabitRPG.Client.Model;
using NUnit.Framework;
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
      var configuration = new HabitRpgConfiguration()
      {
        UserId = Guid.Parse("55a4a342-c8da-4c95-9467-4a304a4ae4bd"),
        ApiToken = Guid.Parse("4a64e99a-de87-4fcc-a8bf-aee21dd59a8c"),
        ServiceUri = new Uri(@"https://habitrpg.com/")
      };

      _habitRpgService = new HabitRPGClient(configuration);
    }

    [Test]
    public async void Should_create_new_todo_task()
    {
      // Setup
      var todo = CreateTodo();

      // Action
      var response = await _habitRpgService.CreateTask(todo);

      // Verify the result
      AssertTask(todo, response);

      Assert.AreEqual(todo.Completed, response.Completed);
      Assert.AreEqual(todo.Archived, response.Archived);
      Assert.AreEqual(todo.Checklist.First().Id, response.Checklist.First().Id);
      Assert.AreEqual(todo.Checklist.First().Text, response.Checklist.First().Text);
      Assert.AreEqual(todo.DateCompleted, response.DateCompleted);
      Assert.AreEqual(todo.Date, response.Date);
      Assert.AreEqual(todo.CollapseChecklist, response.CollapseChecklist);
    }

    [Test]
    public async void Should_create_new_habit_task()
    {
      // Setup
      var habit = CreateHabit();

      // Action
      var response = await _habitRpgService.CreateTask(habit);

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
      var response = await _habitRpgService.CreateTask(daily);

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
      var response = await _habitRpgService.CreateTask(reward);

      // Verify the result
      AssertTask(reward, response);
    }

    [Test]
    public async void Should_return_all_tasks()
    {
      // Setup
      var habitTask = CreateHabit();
      await _habitRpgService.CreateTask(habitTask);

      // Action
      List<Task> response = await _habitRpgService.GetTasks();

      // Verify the result
      Assert.GreaterOrEqual(response.Count, 1);
    }

    [Test]
    public async void Should_return_daily_task()
    {
      // Setup
      Daily daily = CreateDaily();
      await _habitRpgService.CreateTask(daily);

      // Action
      Daily response = await _habitRpgService.GetTask<Daily>(daily.Id);

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
    public async void Should_score_existing_task()
    {
      // Setup
      Daily daily = CreateDaily();
      await _habitRpgService.CreateTask(daily);

      // Action
      var response = await _habitRpgService.ScoreTask(daily.Id.ToString(), Direction.Up);

      Assert.IsNotNull(response);
    }

    [Test]
    public async void Should_create_and_score_new_habit_task()
    {
      // Setup
      string text = DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);

      // Action
      object response = await _habitRpgService.ScoreTask(text, Direction.Up);

      // Verify the result
      var tasks = await _habitRpgService.GetTasks();
      bool exist = tasks.Exists(t => t.Text.Equals(text));

      Assert.IsNotNull(response);
      Assert.IsTrue(exist);
    }

    private static void AssertTask(Task expected, Task actual)
    {
      Assert.AreEqual(expected.Type, actual.Type);
      Assert.AreEqual(expected.Id, actual.Id);
      Assert.AreEqual(expected.DateCreated.ToString(CultureInfo.InvariantCulture), actual.DateCreated.ToString(CultureInfo.InvariantCulture));
      Assert.AreEqual(expected.Text, actual.Text);
      Assert.AreEqual(expected.Notes, actual.Notes);
      Assert.AreEqual(expected.Tags.First().GetHashCode(), actual.Tags.First().GetHashCode());
      Assert.AreEqual(expected.Value, actual.Value);
      Assert.AreEqual(expected.Priority, actual.Priority);
      Assert.AreEqual(expected.Attribute, actual.Attribute);

      //todo: It is bug in API - can't add chalange to daily
      if (expected.Challenge != null)
      {
        Assert.AreEqual(expected.Challenge.First().Id, actual.Challenge.First().Id);
      }
    }

    private static Daily CreateDaily()
    {
      var daily = new Daily()
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
        History = new List<History>()
        {
          new History { Date = DateTime.UtcNow, Value = 1.5107937890723129d}
        },
        //todo: It is bug in API - can't add chalange to daily
        //Challenge = new List<Challenge>()
        //{
        //  new Challenge() {Winner = "User123456", Broken = Broken.ChallengeClosed, Id = Guid.NewGuid()}
        //},
        Completed = false,
        Repeat = new Repeat() { Friday = false, Wednesday = false },
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
      var habitTask = new Habit()
      {
        Id = Guid.NewGuid().ToString(),
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
        History = new List<History>()
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
        Challenge = new List<Challenge>()
        {
          new Challenge() {Winner = "User123456", Broken = Broken.ChallengeClosed, Id = Guid.NewGuid()}
        }
      };

      return reward;
    }
  }
}