using System.Net;
using System.Net.Sockets;
using fastcgi_server.ConfigReader;
using fastcgi_server.ConfigReader.Parser;
using fastcgi_server.ConfigReader.Validator;

namespace fastcgi_server
{
    internal abstract class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var parser = new Parser();
            parser.AddArgParser(new ListenParser());
            parser.AddArgParser(new AppParser());
            parser.AddArgParser(new HelpParser());

            var reader = new ConfigReader.ConfigReader(parser, new Validator());
            if (reader.TryRead(args, out Config config))
            {
                CgiServer cgiServer = new CgiServer(config);
                await cgiServer.Run();
                return 0;
            }
            return -1;
        }
    }

    internal class CgiServer
    {
        private readonly Config _config;

        public CgiServer(Config config)
        {
            _config = config;
        }

        public async Task Run()
        {
            Console.WriteLine("Server run");
            TcpListener? server = null;
            try
            {
                var ipPoint = new IPEndPoint(
                    new IPAddress(Array.ConvertAll(_config.IP, i => (byte)i)),
                    _config.Port);
                server = new TcpListener(ipPoint);
                server.Start();
                Console.WriteLine("Сервер запущен. Ожидание подключений... ");

                while (true)
                {
                    // получаем подключение в виде TcpClient
                    using var tcpClient = await server.AcceptTcpClientAsync();
                    Console.WriteLine($"Входящее подключение: {tcpClient.Client.RemoteEndPoint}");
                    Console.WriteLine();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                Console.WriteLine("Stop");
                server?.Stop();
            }
        }
    }
}