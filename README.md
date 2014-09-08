HabitRPG API .NET Client
==========================

.NET Async HabitRPG Client Library

# How to install

To install HabitRPG.Client, run the following command in the [Package Manager Console](https://www.nuget.org/packages/HabitRPG.Client/)

```
Install-Package HabitRPG.Client
```

# How to use

```cs
var configuration = new HabitRpgConfiguration()
{
  UserId = // UserId guid from HabitRPG,
  ApiToken = // ApiToken guid from HabitRPG,
  ServiceUri = new Uri(@"https://habitrpg.com/")
};

IUserClient _userClient = new UserClient(configuration);

var response = await _userClient.GetTasksAsync();
```

# Supported methods

## IUserClient
```cs

Task<object> ScoreTaskAsync(string id, Direction direction);
Task<List<ITask>> GetTasksAsync();
Task<T> CreateTaskAsync<T>(T task) where T : ITask;
Task<T> GetTaskAsync<T>(string taskId) where T : ITask;
Task<T> UpdateTaskAsync<T>(T task) where T : ITask;
Task DeleteTaskAsync(string taskId);
Task<List<ITask>> ClearCompletedAsync();
Task<List<Item>> GetBuyableItemsAsync();
Task BuyItemAsync(string key);
Task<User> GetUserAsync();

```
## IMembersClient
```cs
Task<Member> GetMemberAsync(string id);
```
## IGroupsClient
```cs
Task<List<Group>> GetGroupsAsync(string types);
Task<Group> GetGroupAsync(string groupId);
Task<List<ChatMessage>> GetGroupChatAsync(string groupId);
Task<ChatMessage> SendChatMessageAsync(string groupId, string message);
Task DeleteChatMessageAsync(string groupId, string messageId);
Task LikeChatMessageAsync(string groupId, string messageId);

```
[![MyGet Build Status](https://www.myget.org/BuildSource/Badge/marska?identifier=21b63643-1cd1-4ac0-9fda-e16de34452ab)](https://www.myget.org/)

