using System;
using System.Collections.Generic;
using HabitRPG.Client.Converters;
using Newtonsoft.Json;

namespace HabitRPG.Client.Model
{
   public class ChatMessage
   {
      public ChatMessage()
      {
         Likes = new Dictionary<Guid, bool>();
      }

      public Guid Id { get; set; }

      public string Text { get; set; }

      [JsonConverter(typeof(TimestampConverter))]
      [JsonProperty("timestamp")]
      public DateTime Timestamp { get; set; }

      [JsonProperty("likes")]
      public Dictionary<Guid, Boolean> Likes { get; set; }

      [JsonProperty("uuid")]
      public Guid UserId { get; set; }

      [JsonProperty("contributor")]
      public Contributor Contributor { get; set; }

      [JsonProperty("user")]
      public string User { get; set; }
   }
}
