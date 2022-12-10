using System.Net;
using fastcgi_server.Parser;

namespace fastcgi_server
{
    internal abstract class Program
    {
        public static int Main(string[] args)
        {
            var parser = new Parser.Parser();
            parser.AddArgParser(new ListenParser());
            parser.AddArgParser(new AppParser());
            parser.AddArgParser(new HelpParser());

            var reader = new ConfigReader(parser, new Validator());
            if (reader.TryRead(args, out Config config))
            {
                CGIServer cgiServer = new CGIServer(config);
                cgiServer.Run();
                return 0;
            }
            return -1;
        }
    }

    internal class CGIServer
    {
        private Config _config;
        private bool _isUp;
        
        public CGIServer(Config config)
        {
            _config = config;
        }

        public void Run()
        {
            Console.WriteLine("Server run");
            // _isUp = true;
            // while (_isUp)
            // {
            //     IPEndPoint ipPoint = new IPEndPoint()
            // }
        }
    }
}