using Newtonsoft.Json;
using System;

namespace HabitRPG.Client.Model
{
   public class Profile
   {
      [JsonProperty("name")]
      public String Name { get; set; }
   }
}
