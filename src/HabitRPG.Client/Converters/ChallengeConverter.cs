using System;
using HabitRPG.Client.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace HabitRPG.Client.Converters
{
    public class ChallengeConverter : CustomCreationConverter<Challenge>
    {
        public override Challenge Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType,
           object existingValue, JsonSerializer serializer)
        {
            try
            {
                // Load JObject from stream
                JObject jObject = JObject.Load(reader);

                // Filter empty values
                if (!jObject.HasValues)
                    return null;

                // Create target
                var target = new Challenge();

                // Populate the object properties
                serializer.Populate(jObject.CreateReader(), target);

                return target;
            }
            catch (Exception e)
            {
                // Filter "challenge: null",  inside JSON
                return null;
            }
        }
    }
}