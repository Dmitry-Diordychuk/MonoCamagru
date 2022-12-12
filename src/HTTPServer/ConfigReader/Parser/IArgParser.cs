namespace MonoCamagru.HTTPServer.ConfigReader.Parser
{
	interface IArgParser
	{
		string Flag { get; }
		List<(string, object)> ParseValue(string input);
	}
}
