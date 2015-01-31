using System.Threading.Tasks;
using HabitRPG.Client.Model;

namespace HabitRPG.Client
{
  public interface IContentClient
  {
     Task<Content> GetContentAsync(string language = "");
    // todo: implement GET /content/paths Show user model tree
  }
}