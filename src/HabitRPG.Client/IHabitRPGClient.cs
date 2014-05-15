using System.Threading.Tasks;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
  public interface IHabitRPGClient
  {
    Task<Todo> CreateTodo(Todo task);
  }
}