using Newtonsoft.Json;
using System;

namespace HabitRPG.Client.Converters
{

	public class GuidConverter : JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(string) || objectType == typeof(Guid);
		}

		public override void WriteJson (JsonWriter writer, object value, JsonSerializer serializer)
		{
			if(value.Equals (Guid.Empty))
			{
				writer.WriteRawValue ("system");
			}
			else
			{
				writer.WriteRawValue (value.ToString ());
			}
		}

		public override object ReadJson (JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if(reader.Value.ToString () == "system")
			{
				return Guid.Empty;
			}
			return new Guid (reader.Value.ToString ());
		}
	}
}