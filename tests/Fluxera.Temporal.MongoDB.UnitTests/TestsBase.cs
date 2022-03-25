namespace Fluxera.Temporal.MongoDB.UnitTests
{
	using System.Text.RegularExpressions;

	public abstract class TestsBase
	{
		protected string Minify(string json)
		{
			return Regex.Replace(json, @"(""(?:[^""\\]|\\.)*"")|\s+", "$1", RegexOptions.Compiled);
		}
	}
}
