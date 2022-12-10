namespace fastcgi_server.Parser
{
	class ListenParser : IArgParser
	{
		public string Flag => "--listen";

		public List<(string, string)> ParseValue(string input)
		{
			var split = input.Split(new[] { ':' });
			return new List<(string, string)>
			{
				("ip", split[0]),
				("port", split[1])
			};
		}
	}

	class AppParser : IArgParser
	{
		public string Flag => "--app";

		public List<(string, string)> ParseValue(string input)
		{
			return new List<(string, string)>
			{
				("appfolder", input)
			};
		}
	}

	class HelpParser : IArgParser
	{
		public string Flag => "--help";
		public List<(string, string)> ParseValue(string input)
		{
			return new List<(string, string)>
			{
				("help", "")
			};
		}
	}
}
