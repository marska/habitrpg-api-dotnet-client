using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class Group
   {
      /// <summary>
      /// DataType is String because the Tavern has the GroupId: habitrpg
      /// </summary>
      [JsonProperty("_id")]
      public string Id { get; set; }

      [JsonProperty("balance")]
      public double Balance { get; set; }

      [JsonProperty("description")]
      public string Description { get; set; }

      [JsonProperty("leader")]
      public Guid Leader { get; set; }

      [JsonProperty("name")]
      public string Name { get; set; }

      [JsonProperty("memberCount")]
      public int MemberCount { get; set; }

      [JsonProperty("type")]
      public string Type { get; set; }

      [JsonProperty("chat")]
      public List<ChatMessage> Chat { get; set; }

      [JsonProperty("member")]
      public List<Member> Members { get; set; } 
   }
}
