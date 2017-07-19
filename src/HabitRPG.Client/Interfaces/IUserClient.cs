using System.Collections.Generic;
using System.Threading.Tasks;
using HabitRPG.Client.Model;
using Task = System.Threading.Tasks.Task;

namespace HabitRPG.Client
{
  public interface IUserClient
  {
    /// <summary>
    /// POST /user/tasks/{id}/{direction}
    /// 
    /// Simple scoring of a task. This is most-likely the only API route you'll be using as a 3rd-party developer.
    /// The most common operation is for the user to gain or lose points based on some action (browsing Reddit, running a mile, 1 Pomodor, etc).
    /// Call this route, if the task you're trying to score doesn't exist, it will be created for you.
    /// </summary>
    /// <param name="id">ID of the task to score. If this task doesn't exist, a task will be created automatically</param>
    /// <param name="direction">Either 'up' or 'down'</param>
    /// <returns>Magic object :)</returns>
    Task<ScoreResult> ScoreTaskAsync(string id, Direction direction);

    /// <summary>
    /// GET /user/tasks Get all user's tasks
    /// 
    /// Get all user's tasks
    /// </summary>
    /// <returns>List of user task</returns>
    Task<List<ITask>> GetTasksAsync();

    /// <summary>
    /// POST /user/tasks Create a task
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="task"></param>
    /// <returns></returns>
    Task<T> CreateTaskAsync<T>(T task) where T : ITask;

    /// <summary>
    /// GET /user/tasks/{id} Get an individual task
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="taskId"></param>
    /// <returns></returns>
    Task<T> GetTaskAsync<T>(string taskId) where T : ITask;

    /// <summary>
    /// PUT /user/tasks/{id} Update a user's task 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="task"></param>
    /// <returns></returns>
    Task<T> UpdateTaskAsync<T>(T task) where T : ITask;

    /// <summary>
    /// DELETE /user/tasks/{id} 
    /// 
    /// Delete a task 
    /// </summary>
    /// <param name="taskId"></param>
    /// <returns></returns>
    Task DeleteTaskAsync(string taskId);

    // todo: implement  POST /user/tasks/{id}/sort Sort tasks

    /// <summary>
    /// POST /user/tasks/clear-completed 
    /// 
    /// Clears competed To-Dos (needed periodically for performance).
    /// </summary>
    /// <returns></returns>
    Task ClearCompletedAsync();

    // todo: implement POST /user/tasks/{id}/unlink 

    /// <summary>
    /// GET /user/inventory/buy
    /// 
    /// Get a list of buyable gear
    /// </summary>
    /// <returns></returns>
    Task<List<Item>> GetBuyableItemsAsync();
    
    /// <summary>
    /// POST /user/inventory/buy/{key}
    /// 
    /// Buy a gear piece and equip it automatically  
    /// </summary>
    /// <param name="key"></param>
    /// <returns></returns>
    Task BuyItemAsync(string key);

    // todo: implement POST /user/inventory/sell/{type}/{key} Sell inventory items back to Alexander
    // todo: implement POST /user/inventory/purchase/{type}/{key} Purchase a gem-purchaseable item from Alexander
    // todo: implement POST /user/inventory/feed/{pet}/{food} Feed your pet some food

    /// <summary>
    /// POST /user/inventory/equip/{type}/{key}
    /// 
    /// Equip an item (either pet, mount, equipped or costume)  
    /// </summary>
    /// <param name="type"></param>
    /// <param name="key"></param>
    /// <returns></returns>
    Task<Items> InventoryEquip(string type, string key);

    // todo: implement POST /user/inventory/hatch/{egg}/{hatchingPotion} Pour a hatching potion on an egg
    
    /// <summary>
    /// GET /user
    /// 
    /// Get the full user object 
    /// </summary>
    /// <returns></returns>
    Task<User> GetUserAsync();

    // todo: implement PUT /user Update the user object (only certain attributes are supported)
    // todo: implement DELETE /user Delete a user object entirely, USE WITH CAUTION!
    // todo: implement POST /user/revive Revive your dead user
    // todo: implement POST /user/reroll Drink the Fortify Potion (Note, it used to be called re-roll)
    // todo: implement POST /user/reset Completely reset your account
    // todo: implement POST /user/sleep Toggle whether you're resting in the inn
    // todo: implement POST /user/rebirth Rebirth your avatar
    // todo: implement POST /user/class/change Either remove your avatar's class, or change it to something new
    // todo: implement POST /user/class/allocate Allocate one point towards an attribute
    // todo: implement POST /user/class/cast/{spell} Casts a spell on a target.
    // todo: implement POST /user/unlock Unlock a certain gem-purchaseable path (or multiple paths)
    // todo: implement POST /user/batch-update This is an advanced route which is useful for apps which might for example need offline support. You can send a whole batch of user-based operations, which allows you to queue them up offline and send them all at once. The format is {op:'nameOfOperation',parameters:{},body:{},query:{}}
    // todo: implement POST /user/tags/sort Sort tags

    /// <summary>
    /// POST /user/tags
    /// 
    /// Create a new tag 
    /// </summary>
    /// <returns></returns>
    Task CreateTagAsync(Tag tag);

    /// <summary>
    /// PUT /user/tags/{id}
    /// 
    /// Update a tag 
    /// </summary>
    /// <returns></returns>
    Task UpdateTagAsync(Tag tag);    
     
    /// <summary>
    /// DELETE /user/tags/{id}
    /// 
    /// Delete a tag 
    /// </summary>
    /// <returns></returns>
    Task DeleteTagAsync(string tagId);
  }
}