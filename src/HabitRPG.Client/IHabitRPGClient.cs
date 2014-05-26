using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitRPG.Client
{
  public interface IHabitRPGClient
  {
    Task<T> CreateTask<T>(T task) where T : Model.Task;

    Task<List<Model.Task>> GetTasks();

    Task<T> GetTask<T>(string id) where T : Model.Task;

    /// <summary>
    /// Simple scoring of a task. This is most-likely the only API route you'll be using as a 3rd-party developer. 
    /// The most common operation is for the user to gain or lose points based on some action (browsing Reddit, running a mile, 1 Pomodor, etc). 
    /// Call this route, if the task you're trying to score doesn't exist, it will be created for you.
    /// </summary>
    /// <param name="id">ID of the task to score. If this task doesn't exist, a task will be created automatically</param>
    /// <param name="direction">Either 'up' or 'down'</param>
    /// <returns>Magic object :)</returns>
    Task<object> ScoreTask(string id, string direction);
  }
}