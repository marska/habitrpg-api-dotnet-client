using System.Collections.Generic;
using System.Threading.Tasks;

namespace HabitRPG.Client
{
   public interface IHabitRPGClient
   {
      Task<T> CreateTaskAsync<T>(T task) where T : Model.ITask;

      /// <summary>
      /// Get all user's tasks
      /// </summary>
      /// <returns>List of user task</returns>
      Task<List<Model.ITask>> GetTasksAsync();

      Task<T> GetTaskAsync<T>(string id) where T : Model.ITask;

      Task<T> UpdateTaskAsync<T>(T taskObj) where T : Model.ITask;

      Task DeleteTaskAsync(string id);

      Task<List<Model.ITask>> ClearCompletedAsync();

      Task<Model.User> GetUserAsync();

      Task<Model.Member> GetMemberAsync(string id);

      /// <summary>
      /// Simple scoring of a task. This is most-likely the only API route you'll be using as a 3rd-party developer.
      /// The most common operation is for the user to gain or lose points based on some action (browsing Reddit, running a mile, 1 Pomodor, etc).
      /// Call this route, if the task you're trying to score doesn't exist, it will be created for you.
      /// </summary>
      /// <param name="id">ID of the task to score. If this task doesn't exist, a task will be created automatically</param>
      /// <param name="direction">Either 'up' or 'down'</param>
      /// <returns>Magic object :)</returns>
      Task<object> ScoreTaskAsync(string id, string direction);
   }
}