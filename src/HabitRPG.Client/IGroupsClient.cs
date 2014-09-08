using HabitRPG.Client.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace HabitRPG.Client
{
  public interface IGroupsClient
  {
    // todo: implement groups Show/Hide List Operations Expand Operations Raw

    /// <summary>
    /// GET /groups Get a list of groups 
    /// </summary>
    /// <param name="types"></param>
    /// <returns></returns>
    Task<List<Group>> GetGroupsAsync(string types);

    // todo: implement POST /groups Create a group

    /// <summary>
    /// GET /groups/{gid} 
    /// 
    /// Get a group. The party the user currently is in can be accessed with the gid 'party'.
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    Task<Group> GetGroupAsync(string groupId);

    // todo: implement POST /groups/{gid} Edit a group
    // todo: implement POST /groups/{gid}/join Join a group
    // todo: implement POST /groups/{gid}/leave Leave a group
    // todo: implement POST /groups/{gid}/invite Invite a user to a group
    // todo: implement POST /groups/{gid}/removeMember Remove / boot a member from a group
    // todo: implement POST /groups/{gid}/questAccept Accept a quest invitation
    // todo: implement POST /groups/{gid}/questReject Reject quest invitation
    // todo: implement POST /groups/{gid}/questAbort Abort quest

    /// <summary>
    /// GET /groups/{gid}/chat 
    /// Get all chat messages
    /// </summary>
    /// <param name="groupId"></param>
    /// <returns></returns>
    Task<List<ChatMessage>> GetGroupChatAsync(string groupId);

    /// <summary>
    /// POST /groups/{gid}/chat 
    /// 
    /// Send a chat message
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="message"></param>
    /// <returns></returns>
    Task<ChatMessage> SendChatMessageAsync(string groupId, string message);

    // todo: implement POST /groups/{gid}/chat/seen Flag chat messages for a particular group as seen

    /// <summary>
    /// DELETE /groups/{gid}/chat/{messageId} Delete a chat message in a given group
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="messageId"></param>
    /// <returns></returns>
    Task DeleteChatMessage(string groupId, string messageId);

    /// <summary>
    /// POST /groups/{gid}/chat/{mid}/like 
    /// 
    /// Like a chat message  
    /// </summary>
    /// <param name="groupId"></param>
    /// <param name="messageId"></param>
    /// <returns></returns>
    Task LikeChatMessage(string groupId, string messageId);
  }
}