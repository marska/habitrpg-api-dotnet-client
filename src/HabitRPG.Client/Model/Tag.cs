using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HabitRPG.Client.Model
{
   public class Tag
   {
      [JsonProperty("id")]
      public Guid Id { get; set; }

      [JsonProperty("name")]
      public String Name { get; set; }
   }
}
