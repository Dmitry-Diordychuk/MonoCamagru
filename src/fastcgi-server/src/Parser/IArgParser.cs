namespace fastcgi_server.Parser
{
	interface IArgParser
	{
		string Flag { get; }
		List<(string, string)> ParseValue(string input);
	}
}
