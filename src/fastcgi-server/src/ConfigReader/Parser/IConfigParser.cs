namespace fastcgi_server.Parser
{
	interface IConfigParser
	{
		void AddArgParser(IArgParser typeParser);
		Dictionary<string, object> Parse(string[] input);
	}
}
