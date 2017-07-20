using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;

namespace HabitRPG.Client.Converters
{
    internal class TaskConverter : CustomCreationConverter<Model.ITask>
    {
        public override Model.ITask Create(Type objectType)
        {
            throw new NotImplementedException();
        }

        public Model.ITask Create(Type objectType, JObject jObject)
        {
            var type = (string)jObject.Property("type");

            switch (type)
            {
                case "daily":
                    return new Model.Daily();

                case "habit":
                    return new Model.Habit();

                case "todo":
                    return new Model.Todo();

                case "reward":
                    return new Model.Reward();
            }

            throw new Exception(String.Format("Type: {0} not supported", type));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Load JObject from stream
            JObject jObject = JObject.Load(reader);

            // Create target object based on JObject
            var target = Create(objectType, jObject);

            // Populate the object properties
            serializer.Populate(jObject.CreateReader(), target);

            return target;
        }
    }
}