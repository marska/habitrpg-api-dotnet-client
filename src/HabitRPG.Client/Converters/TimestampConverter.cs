using Newtonsoft.Json;
using System;

namespace HabitRPG.Client.Converters
{
    public class TimestampConverter : JsonConverter
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var dateTime = ((DateTime)value).ToUniversalTime();

            var intMilliseconds = (Int64)((dateTime - _epoch).TotalMilliseconds);

            writer.WriteRawValue(intMilliseconds.ToString());
        }

        // SO MANY different values inside a DateTime Property...
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.Value is DateTime)
                return reader.Value;

            if (reader.Value == null)
                return _epoch;

            long longValue;

            if (long.TryParse(reader.Value.ToString(), out longValue))
                return _epoch.AddMilliseconds(longValue);

            DateTime dateTime;

            if (DateTime.TryParse(reader.Value.ToString(), out dateTime))
                return dateTime;

            return _epoch;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateTime);
        }
    }
}