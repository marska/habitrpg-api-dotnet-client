using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class Profile
   {
      [JsonProperty("name")]
      public String Name { get; set; }
   }
}
