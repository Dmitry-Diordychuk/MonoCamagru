namespace fastcgi_server.ConfigReader.Parser
{
	interface IConfigParser
	{
		void AddArgParser(IArgParser typeParser);
		Dictionary<string, object> Parse(string[] input);
	}
}
