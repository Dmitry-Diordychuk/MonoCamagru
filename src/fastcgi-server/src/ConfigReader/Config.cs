namespace fastcgi_server
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
