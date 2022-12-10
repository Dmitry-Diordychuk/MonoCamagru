using FastCgi;

namespace fastcgi_server.Parser
{
	class ConfigParser : IConfigParser
	{
		private readonly Dictionary<string, Func<string, List<(string, string)>>> _parsers = new ();

		public void AddArgParser(IArgParser argParser)
		{
			_parsers[argParser.Flag] = argParser.ParseValue;
		}

		public Dictionary<string, string> Parse(string[] args)
		{
			var parameters = new Dictionary<string, string>();

			for (int i = 0; i < args.Length; i++)
			{
				var currentFlag = args[i].ToLower();
				if (_parsers.TryGetValue(currentFlag, out var parse))
				{
					if (i + 1 < args.Length && !IsFlag(args[i + 1]))
					{
						parse(args[i + 1]).ForEach(x => parameters[x.Item1] = x.Item2);
						i++;
					}
					else
					{
						parse("").ForEach(x => parameters[x.Item1] = x.Item2);
					}
				}
				else
				{
					Console.WriteLine(IsFlag(currentFlag)
						? $"Unknown argument {currentFlag}"
						: $"Wrong input {currentFlag}");
				}
			}
			return parameters;
		}

		private bool IsFlag(string str)
		{
			return str.Length >= 3 && str[0] == '-' && str[1] == '-';
		}
	}
}
