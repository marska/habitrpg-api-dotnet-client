using System.Threading.Tasks;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
	public interface IStatusClient
	{
		Task<Status> GetStatusAsync();
	}
}