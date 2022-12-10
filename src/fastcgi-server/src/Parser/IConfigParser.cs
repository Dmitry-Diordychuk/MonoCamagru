using System.Collections.Generic;
using fastcgi_server.Parser;

namespace FastCgi
{
	interface IConfigParser
	{
		void AddArgParser(IArgParser typeParser);
		Dictionary<string, string> Parse(string[] input);
	}
}
