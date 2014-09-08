HabitRPG API .NET Client
==========================

Simple .NET HabitRPG Client Library

# How to install

To install HabitRPG.Client, run the following command in the [Package Manager Console](https://www.nuget.org/packages/HabitRPG.Client/)

```
Install-Package HabitRPG.Client -Pre
```

# How to use

```cs
var configuration = new HabitRpgConfiguration()
{
  UserId = // UserId guid from HabitRPG,
  ApiToken = // ApiToken guid from HabitRPG,
  ServiceUri = new Uri(@"https://habitrpg.com/")
};

IHabitRPGClient _habitRpgService = new HabitRPGClient(configuration);

var habitTask = new Todo
{
  Text = "My todo" 
};

var response = await _habitRpgService.CreateTask(todo);
```

# Implemented methods

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

[![MyGet Build Status](https://www.myget.org/BuildSource/Badge/marska?identifier=21b63643-1cd1-4ac0-9fda-e16de34452ab)](https://www.myget.org/)

