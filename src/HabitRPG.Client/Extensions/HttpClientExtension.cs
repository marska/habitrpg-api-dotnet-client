using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace HabitRPG.Client.Extensions
{
   public static class HttpClientExtension
   {
      public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string url, object obj)
      {
         var jsonContent = JsonConvert.SerializeObject(obj);

         var postMessage = new StringContent(jsonContent, Encoding.UTF8, "application/json");

         return client.PostAsync(url, postMessage);
      }

      public static Task<HttpResponseMessage> PutAsJsonAsync(this HttpClient client, string url, object obj)
      {
         var jsonContent = JsonConvert.SerializeObject(obj);

         var postMessage = new StringContent(jsonContent, Encoding.UTF8, "application/json");

         return client.PutAsync(url, postMessage);
      }
   }
}
