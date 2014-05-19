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

```cs
Task<T> CreateTask<T>(T task) where T : Model.Task;
```
