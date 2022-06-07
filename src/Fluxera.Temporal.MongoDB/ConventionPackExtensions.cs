namespace Fluxera.Temporal.MongoDB
{
	using global::MongoDB.Bson.Serialization.Conventions;
	using JetBrains.Annotations;

	/// <summary>
	///     Extension methods for the <see cref="ConventionPack" /> type.
	/// </summary>
	[PublicAPI]
	public static class ConventionPackExtensions
	{
		/// <summary>
		///     Configures the database to use the temporal serializers.
		/// </summary>
		/// <param name="pack"></param>
		/// <returns></returns>
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
