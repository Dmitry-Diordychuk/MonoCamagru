using System;
using fastcgi_server;

namespace FastCgi
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
			config.IP = "";
			config.Port = "";

			if (parameters.ContainsKey("help"))
			{
				PrintHelpMessage();
				return false;
			}

			if (_validator.Validate(parameters))
			{
				config = _validator.Config;
				Console.WriteLine("--Config analysis--");
				Console.WriteLine($"Ip: {config.IP}");
				Console.WriteLine($"Port: {config.Port}");
				Console.WriteLine($"App Folder: {config.AppFolder}");
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
