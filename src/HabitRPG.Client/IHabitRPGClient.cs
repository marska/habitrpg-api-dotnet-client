using System.Threading.Tasks;

namespace HabitRPG.Client
{
  public interface IHabitRPGClient
  {
    Task<Model.Todo> CreateTodo(Model.Todo task);
  }
}