using System;
using System.Collections.Generic;
using HabitRPG.Client.Converters;
using Newtonsoft.Json;

namespace HabitRPG.Client
{
  public class HabitRpgConfiguration
  {
    public HabitRpgConfiguration()
    {
      SerializerSettings = new JsonSerializerSettings
      {
        Converters = new List<JsonConverter>
            {
               new TaskConverter(),
               new ChallengeConverter()
            },

#if DEBUG
        Error = (sender, args) =>
        {
          if (System.Diagnostics.Debugger.IsAttached)
          {
            System.Diagnostics.Debugger.Break();
          }
        }
#endif
      };
    }

    public Guid ApiToken { get; set; }

    public Guid UserId { get; set; }

    public Uri ServiceUri { get; set; }

    public JsonSerializerSettings SerializerSettings { get; set; }
  }
}