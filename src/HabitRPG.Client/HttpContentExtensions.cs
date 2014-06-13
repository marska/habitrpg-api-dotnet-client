using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HabitRPG.Client
{
   static class HttpContentExtensions
   {
      public static async Task<T> ReadAsAsync<T>(this HttpContent content)
      {
         var contentJson = await content.ReadAsStringAsync();

         var obj = JsonConvert.DeserializeObject<T>(contentJson);

         return obj;
      }
   }
}
