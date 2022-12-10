namespace fastcgi_server.Parser
{
	interface IArgParser
	{
		string Flag { get; }
		List<(string, object)> ParseValue(string input);
	}
}
