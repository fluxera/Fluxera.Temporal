namespace Fluxera.Temporal.MongoDB
{
	using System;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Serializers;
	using JetBrains.Annotations;

	[PublicAPI]
	public class TimeOnlySerializer : StructSerializerBase<TimeOnly>
	{
		private readonly TimeSpanSerializer timeSpanSerializer = new TimeSpanSerializer();

		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, TimeOnly value)
		{
			this.timeSpanSerializer.Serialize(context, args, value.ToTimeSpan());
		}

		public override TimeOnly Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			TimeSpan timeSpan = this.timeSpanSerializer.Deserialize(context, args);
			return TimeOnly.FromTimeSpan(timeSpan);
		}
	}
}
