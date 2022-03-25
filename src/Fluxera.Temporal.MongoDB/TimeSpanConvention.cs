namespace Fluxera.Temporal.MongoDB
{
	using System;
	using Fluxera.Utilities.Extensions;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Conventions;
	using global::MongoDB.Bson.Serialization.Serializers;

	internal sealed class TimeSpanConvention : ConventionBase, IMemberMapConvention
	{
		/// <inheritdoc />
		public void Apply(BsonMemberMap memberMap)
		{
			Type originalMemberType = memberMap.MemberType;
			Type memberType = originalMemberType.UnwrapNullableType();

			if(memberType == typeof(TimeSpan))
			{
				TimeSpanSerializer timeSpanSerializer = new TimeSpanSerializer();

				IBsonSerializer serializer = originalMemberType.IsNullable()
					? new NullableSerializer<TimeSpan>(timeSpanSerializer)
					: timeSpanSerializer;

				memberMap.SetSerializer(serializer);
			}
		}
	}
}
