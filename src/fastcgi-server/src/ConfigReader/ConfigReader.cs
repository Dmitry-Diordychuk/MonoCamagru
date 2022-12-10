using fastcgi_server.Parser;

namespace fastcgi_server
{
	class ConfigReader
	{
		public Config config { get; }

		private IConfigParser _parser;
		private IConfigValidator _validator;

		public ConfigReader(IConfigParser parser, IConfigValidator validator)
		{
			_parser = parser;
			_validator = validator;
		}

		public bool TryRead(string[] input, out Config config)
		{
			var parameters = _parser.Parse(input);

			config.AppFolder = "";
			config.IP = new [] { -1, -1, -1, -1 };
			config.Port = -1;

			if (parameters.ContainsKey("help"))
			{
				PrintHelpMessage();
				return false;
			}

			if (_validator.Validate(parameters))
			{
				config = _validator.Config;
				return true;
			}

			Console.WriteLine("Config reading failed!");
			return false;
		}

		private void PrintHelpMessage()
		{
			Console.WriteLine("This is FastCGI server");
			Console.WriteLine("Return: C# script result");
			Console.WriteLine("");
			Console.WriteLine("Required arguments:");
			Console.WriteLine("--listen ipv4:port");
			Console.WriteLine("--app /C#/script/folder/Program.cs");
			Console.WriteLine("");
			Console.WriteLine("Possible argument:");
			Console.WriteLine("--help show this help ;)");
		}
	}
}
