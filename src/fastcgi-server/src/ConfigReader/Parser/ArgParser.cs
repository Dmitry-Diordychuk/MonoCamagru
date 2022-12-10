namespace fastcgi_server.Parser
{
	class ListenParser : IArgParser
	{
		public string Flag => "--listen";

		public List<(string, object)> ParseValue(string input)
		{
			List<int> resultIp = new List<int>();
			int resultPort = 0;
			var ipPort = input.Split(new[] { ':' });
			var ip = ipPort[0].Split(new [] { '.' });
			
			foreach (var part in ip)
			{
				resultIp.Add(Int32.Parse(part));
			}

			resultPort = Int32.Parse(ipPort[1]);
			
			return new List<(string, object)>
			{
				("ip", resultIp.ToArray()),
				("port", resultPort)
			};
		}
	}

	class AppParser : IArgParser
	{
		public string Flag => "--app";

		public List<(string, object)> ParseValue(string input)
		{
			return new List<(string, object)>
			{
				("appfolder", input)
			};
		}
	}

	class HelpParser : IArgParser
	{
		public string Flag => "--help";
		public List<(string, object)> ParseValue(string input)
		{
			return new List<(string, object)>
			{
				("help", "")
			};
		}
	}
}
