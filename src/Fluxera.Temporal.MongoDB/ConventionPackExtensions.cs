namespace Fluxera.Temporal.MongoDB
{
	using global::MongoDB.Bson.Serialization.Conventions;
	using JetBrains.Annotations;

	[PublicAPI]
	public static class ConventionPackExtensions
	{
		public static ConventionPack UseTemporal(this ConventionPack pack)
		{
			pack.Add(new DateTimeConvention());
			pack.Add(new DateTimeOffsetConvention());
			pack.Add(new DateOnlyConvention());
			pack.Add(new TimeOnlyConvention());
			pack.Add(new TimeSpanConvention());

			return pack;
		}
	}
}
