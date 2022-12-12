using MonoCamagru.HTTPServer.ConfigReader.Validator;

namespace MonoCamagru.HTTPServer.ConfigReader
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
