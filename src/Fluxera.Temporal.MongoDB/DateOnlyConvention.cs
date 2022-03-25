namespace Fluxera.Temporal.MongoDB
{
	using System;
	using Fluxera.Utilities.Extensions;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Conventions;
	using global::MongoDB.Bson.Serialization.Serializers;

	internal sealed class DateOnlyConvention : ConventionBase, IMemberMapConvention
	{
		/// <inheritdoc />
		public void Apply(BsonMemberMap memberMap)
		{
			Type originalMemberType = memberMap.MemberType;
			Type memberType = originalMemberType.UnwrapNullableType();

			if(memberType == typeof(DateOnly))
			{
				DateOnlySerializer dateOnlySerializer = new DateOnlySerializer();

				IBsonSerializer serializer = originalMemberType.IsNullable()
					? new NullableSerializer<DateOnly>(dateOnlySerializer)
					: dateOnlySerializer;

				memberMap.SetSerializer(serializer);
			}
		}
	}
}
