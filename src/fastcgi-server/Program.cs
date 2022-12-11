using System.Net;
using System.Net.Sockets;
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
                CgiServer cgiServer = new CgiServer(config);
                cgiServer.Run();
                return 0;
            }
            return -1;
        }
    }

    internal class CgiServer
    {
        private Config _config;
        private bool _isUp;
        
        public CgiServer(Config config)
        {
            _config = config;
        }

        public void Run()
        {
            Console.WriteLine("Server run");
            // _isUp = true;
            // while (_isUp)
            // {
            IPEndPoint ipPoint = new IPEndPoint(
                new IPAddress(Array.ConvertAll(_config.IP, i => (byte)i)),
                _config.Port);
            using Socket socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            // }
        }
    }
}