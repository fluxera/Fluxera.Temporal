namespace Fluxera.Temporal.MongoDB
{
	using System;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Serializers;
	using JetBrains.Annotations;

	/// <summary>
	///     A <see cref="DateTimeOffsetSerializer" /> that only serializes the date part.
	/// </summary>
	[PublicAPI]
	public class DateOnlyDateTimeOffsetSerializer : DateTimeOffsetSerializer
	{
		private readonly DateTimeSerializer dateTimeSerializer;

		/// <summary>
		///     Initializes a new instance of the <see cref="DateOnlyDateTimeOffsetSerializer" />.
		/// </summary>
		/// <param name="dateTimeSerializer"></param>
		public DateOnlyDateTimeOffsetSerializer(DateTimeSerializer dateTimeSerializer)
		{
			this.dateTimeSerializer = dateTimeSerializer;
		}

		/// <inheritdoc />
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, DateTimeOffset value)
		{
			this.dateTimeSerializer.Serialize(context, args, value.Date);
		}

		/// <inheritdoc />
		public override DateTimeOffset Deserialize(BsonDeserializationContext context, BsonDeserializationArgs args)
		{
			DateTimeOffset dateTimeOffset = this.dateTimeSerializer.Deserialize(context, args);
			return dateTimeOffset.Date;
		}
	}
}
