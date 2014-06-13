using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HabitRPG.Client
{
   public static class HttpClientExtensions
   {
      public static Task<HttpResponseMessage> PostAsJsonAsync(this HttpClient client, string url, object obj)
      {
         var jsonContent = JsonConvert.SerializeObject(obj);

         var postMessage = new StringContent(jsonContent, Encoding.UTF8, "application/json");

         return client.PostAsync(url, postMessage);
      }
   }
}
