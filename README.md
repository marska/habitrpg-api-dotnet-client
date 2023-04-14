# HabitRPG API .NET Client

.NET Async HabitRPG Client Library

[![MyGet Build Status](https://www.myget.org/BuildSource/Badge/marska?identifier=21b63643-1cd1-4ac0-9fda-e16de34452ab)](https://www.myget.org/)

# How to install

To install HabitRPG.Client, run the following command in the [Package Manager Console](https://www.nuget.org/packages/HabitRPG.Client/)

```
Install-Package HabitRPG.Client
```

# How to use

```cs
var configuration = new HabitRpgConfiguration()
{
  UserId = "",// UserId guid from HabitRPG,
  ApiToken =  "",// ApiToken guid from HabitRPG,
  ServiceUri = new Uri("https://habitica.com/")
};

IUserClient _userClient = new UserClient(configuration);

var response = await _userClient.GetTasksAsync();
var alltasks = response.ToDetailedList();
alltasks.Todos.ForEach(x => Console.WriteLine(x.Text));

var NewTask = await _userClient.CreateTaskAsync(new Todo()
{
    Text = "update HabitRPG.Client readme",
    Notes = "update readme",
    Checklist = new List<Checklist>()
});

Daily daily = new Daily()
{
    Text = "Brush Teeth",
    Notes = "Brush, don't forget to floss", // optional
    Repeat = new Repeat()
    {
        Saturday = false //all days are true by default, set to false to disable
    },
    Priority = 0.1f // optional, default is 1, 0.1f trivial, 1 easy,  1.5f medium, 2 hard
};

> if the task does not show up it could be that you miss a Checklist parameter in the task

```

# Supported methods

## IUserClient

```cs

Task<ScoreResult> ScoreTaskAsync(string id, Direction direction);
Task<List<ITask>> GetTasksAsync();
Task<T> CreateTaskAsync<T>(T task) where T : ITask;
Task<T> GetTaskAsync<T>(string taskId) where T : ITask;
Task<T> UpdateTaskAsync<T>(T task) where T : ITask;
Task DeleteTaskAsync(string taskId);
Task<List<ITask>> ClearCompletedAsync();
Task<List<Item>> GetBuyableItemsAsync();
Task BuyItemAsync(string key);
Task<User> GetUserAsync();
Task CreateTagAsync(Tag tag);
Task UpdateTagAsync(Tag tag);
Task DeleteTagAsync(string tagId);

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

## IContentClient

```cs
Task<Content> GetContentAsync(string language = "");
```
