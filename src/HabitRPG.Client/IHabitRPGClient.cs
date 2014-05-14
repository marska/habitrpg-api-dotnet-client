using System.Threading.Tasks;

namespace HabitRPG.Client
{
  public interface IHabitRPGClient
  {
    Task<Model.Task> CreateTask(Model.Task task);
  }
}