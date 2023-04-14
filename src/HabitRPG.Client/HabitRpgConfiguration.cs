using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using HabitRPG.Client.Converters;
using Newtonsoft.Json;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace HabitRPG.Client
{
    public class HabitRpgConfiguration
    {
        public HabitRpgConfiguration()
        {
            SerializerSettings = new JsonSerializerSettings
            {
                Converters = (IList<JsonConverter>)new List<JsonConverter>
                {
                    new TaskConverter(),
                    new ChallengeConverter(),
                    new TimestampConverter(),
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