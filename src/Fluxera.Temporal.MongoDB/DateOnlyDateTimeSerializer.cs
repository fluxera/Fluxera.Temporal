namespace Fluxera.Temporal.MongoDB
{
	using System;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Serializers;
	using JetBrains.Annotations;

	[PublicAPI]
	public class DateOnlyDateTimeSerializer : DateTimeSerializer
	{
		private readonly DateTimeSerializer dateTimeSerializer;

		public DateOnlyDateTimeSerializer(DateTimeSerializer dateTimeSerializer)
		{
			this.dateTimeSerializer = dateTimeSerializer;
		}

		/// <inheritdoc />
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTime value)
		{
			this.dateTimeSerializer.Serialize(context, args, value.Date);
		}

		/// <inheritdoc />
		public override DateTime Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			DateTime dateTime = this.dateTimeSerializer.Deserialize(context, args);
			return dateTime.Date;
		}
	}
}
