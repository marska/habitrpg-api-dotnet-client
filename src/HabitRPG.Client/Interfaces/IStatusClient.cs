using System.Threading.Tasks;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
	public interface IStatusClient
	{
		/// <summary>
		/// GET /status Returns the status of the server (up or down)
		/// 
		/// Returns the status of the server (up or down)
		/// </summary>
		/// <returns>Status class holding the server status string</returns>
		Task<ServerStatus> GetStatusAsync();
	}
}