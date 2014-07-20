using Newtonsoft.Json;
using System;

namespace HabitRPG.Client.Converters
{
   public class TimestampConverter : Newtonsoft.Json.JsonConverter
   {
      private readonly DateTime _epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         var dateTime = (DateTime)value;

         var intMilliseconds = (Int64)((dateTime - _epoch).TotalMilliseconds * 1000d);

         writer.WriteRawValue(intMilliseconds.ToString());
      }

      // SO MANY different values inside a DateTime Property...
      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         if (reader.Value is DateTime)
            return reader.Value;

         if (reader.Value == null)
            return DateTime.MinValue;

         long longValue;

         if (long.TryParse(reader.Value.ToString(), out longValue))
            return _epoch.AddMilliseconds(longValue / 1000d);

         DateTime dateTime;

         if (DateTime.TryParse(reader.Value.ToString(), out dateTime))
            return dateTime;

         return DateTime.MinValue;
      }

      public override bool CanConvert(Type objectType)
      {
         return objectType == typeof(DateTime);
      }
   }
}