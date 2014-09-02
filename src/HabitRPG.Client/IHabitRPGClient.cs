using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HabitRPG.Client.Model;
using Task = System.Threading.Tasks.Task;

namespace HabitRPG.Client
{
   public interface IHabitRPGClient
   {
      T GetResult<T>(HttpResponseMessage response);

      HttpClient HttpClient { get; }

      ILogger Logger { get; set; }

      Task<T> CreateTaskAsync<T>(T task) where T : Model.ITask;

      /// <summary>
      /// Get all user's tasks
      /// </summary>
      /// <returns>List of user task</returns>
      Task<List<ITask>> GetTasksAsync();

      Task<T> GetTaskAsync<T>(string id) where T : Model.ITask;

      Task<T> UpdateTaskAsync<T>(T taskObj) where T : Model.ITask;

      Task DeleteTaskAsync(string id);

      Task<List<ITask>> ClearCompletedAsync();

      Task<User> GetUserAsync();

      Task<Member> GetMemberAsync(string id);

      /// <summary>
      /// Simple scoring of a task. This is most-likely the only API route you'll be using as a 3rd-party developer.
      /// The most common operation is for the user to gain or lose points based on some action (browsing Reddit, running a mile, 1 Pomodor, etc).
      /// Call this route, if the task you're trying to score doesn't exist, it will be created for you.
      /// </summary>
      /// <param name="id">ID of the task to score. If this task doesn't exist, a task will be created automatically</param>
      /// <param name="direction">Either 'up' or 'down'</param>
      /// <returns>Magic object :)</returns>
      Task<object> ScoreTaskAsync(string id, Direction direction);
      
      Task<List<Item>> GetBuyableItemsAsync();

      Task BuyItemAsync(string key);

      /// <summary>
      /// Returns the Groups
      /// </summary>
      /// <param name="types">comma-separated types of groups e.g. party,guilds,public,tavern</param>
      /// <returns>List of Groups</returns>
      Task<List<Group>> GetGroupsAsync(string types);

      Task<Group> GetGroupAsync(string groupId);

      Task<List<ChatMessage>> GetGroupChatAsync(string groupId);

      Task<ChatMessage> PostChatMessageAsync(string groupId, string message);

      Task SetGroupChatAsSeenAsync();

      Task LikeChatMessage(string groupId, string messageId);

      Task DeleteChatMessage(string groupId, string messageId);

   }
}