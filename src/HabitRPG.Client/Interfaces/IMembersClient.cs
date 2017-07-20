using System.Threading.Tasks;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
    public interface IMembersClient
    {
        /// <summary>
        /// GET /members/{uid}
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Member> GetMemberAsync(string id);

    }
}