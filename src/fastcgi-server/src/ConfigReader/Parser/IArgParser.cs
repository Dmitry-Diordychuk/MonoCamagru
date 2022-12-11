namespace fastcgi_server.ConfigReader.Parser
{
	interface IArgParser
	{
		string Flag { get; }
		List<(string, object)> ParseValue(string input);
	}
}
