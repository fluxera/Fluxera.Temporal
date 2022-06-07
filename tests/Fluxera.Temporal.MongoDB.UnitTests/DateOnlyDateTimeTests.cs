namespace Fluxera.Temporal.MongoDB.UnitTests
{
	using System;
	using FluentAssertions;
	using Fluxera.ComponentModel.Annotations;
	using global::MongoDB.Bson;
	using global::MongoDB.Bson.IO;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Conventions;
	using NUnit.Framework;

	[TestFixture]
	public class DateOnlyDateTimeTests : TestsBase
	{
		[SetUp]
		public void SetUp()
		{
			ConventionPack pack = new ConventionPack();
			pack.UseTemporal();
			ConventionRegistry.Register("ConventionPack", pack, _ => true);
		}

		private class TestClass
		{
			[DateOnly]
			public DateTime Property { get; set; }
		}

		[Test]
		public void ShouldDeserialize()
		{
			string json = @"{""Property"" : ""2022-04-01""}";
			TestClass result = BsonSerializer.Deserialize<TestClass>(json);

			result.Should().NotBeNull();
			result.Property.Should().Be(new DateTime(2022, 4, 1));
		}

		[Test]
		public void ShouldSerialize()
		{
			TestClass obj = new TestClass
			{
				Property = new DateTime(2022, 4, 1, 10, 0, 0)
			};

			string json = obj.ToJson(new JsonWriterSettings
			{
				Indent = true
			});

			Console.WriteLine(json);
			json.Should().Contain(@"""2022-04-01""");
		}
	}
}
