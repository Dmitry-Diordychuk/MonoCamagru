using fastcgi_server.ConfigReader.Validator;

namespace fastcgi_server.ConfigReader
{
	struct Config
	{
		[IPValidation]
		public int[] IP;

		[PortValidation]
		public int Port;

		[AppFolderValidation]
		public string AppFolder;
	}
}
