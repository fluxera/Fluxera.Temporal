namespace Fluxera.Temporal.MongoDB.UnitTests
{
	using System;
	using FluentAssertions;
	using global::MongoDB.Bson;
	using global::MongoDB.Bson.IO;
	using global::MongoDB.Bson.Serialization;
	using global::MongoDB.Bson.Serialization.Conventions;
	using NUnit.Framework;

	[TestFixture]
	public class TimeOnlyTests : TestsBase
	{
		[SetUp]
		public void SetUp()
		{
			ConventionPack pack = new ConventionPack();
			pack.UseTemporal();
			ConventionRegistry.Register("ConventionPack", pack, t => true);
		}

		private class TestClass
		{
			public TimeOnly Property { get; set; }
		}

		[Test]
		public void ShouldDeserialize()
		{
			string json = @"{""Property"" : ""10:45:35.8471835""}";
			TestClass result = BsonSerializer.Deserialize<TestClass>(json);

			result.Should().NotBeNull();
			result.Property.Should().Be(TimeOnly.Parse("10:45:35.8471835"));
		}

		[Test]
		public void ShouldSerialize()
		{
			TestClass obj = new TestClass
			{
				Property = TimeOnly.Parse("10:45:35.8471835")
			};

			string json = obj.ToJson(new JsonWriterSettings
			{
				Indent = true
			});

			Console.WriteLine(json);
			json.Should().Contain(@"""10:45:35.8471835""");
		}
	}
}
