using System.Collections.Generic;
using System.Linq;

namespace HabitRPG.Client.Model;

public class FullTasksObject
{
    public List<Todo> Todos { get; set; }
    public List<Habit> Habits { get; set; }
    public List<Daily> Dailys { get; set; }
    public List<Reward> Rewards { get; set; }
}
public static class FullTaskObjectExtensions
{
    public static FullTasksObject ToDetailedList(this IList<ITask> tasksList)
    {
        List<Todo> todos = tasksList.Where(x => x.Type == "todo").Select(x => (Todo)x).ToList();
        List<Daily> dailies = tasksList.Where(x => x.Type == "daily").Select(x => (Daily)x).ToList();
        List<Habit> habits = tasksList.Where(x => x.Type == "habit").Select(x => (Habit)x).ToList();
        List<Reward> rewards = tasksList.Where(x => x.Type == "reward").Select(x => (Reward)x).ToList();
        return new FullTasksObject()
        {
            Todos = todos,
            Dailys = dailies,
            Habits = habits,
            Rewards = rewards
        };
    }
}