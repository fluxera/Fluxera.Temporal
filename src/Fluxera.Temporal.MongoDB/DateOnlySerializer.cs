namespace Fluxera.Temporal.MongoDB
{
	using System;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Serializers;
	using JetBrains.Annotations;

	[PublicAPI]
	public class DateOnlySerializer : StructSerializerBase<DateOnly>
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateOnly value)
		{
			context.Writer.WriteString(value.ToString("yyyy-MM-dd"));
		}

		public override DateOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			return DateOnly.ParseExact(context.Reader.ReadString(), "yyyy-MM-dd", null);
		}
	}
}
