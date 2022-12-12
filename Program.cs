using System.Net;
using System.Net.Sockets;
using MonoCamagru.HTTPServer.ConfigReader;
using MonoCamagru.HTTPServer.ConfigReader.Parser;
using MonoCamagru.HTTPServer.ConfigReader.Validator;

namespace MonoCamagru
{
    internal abstract class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var parser = new Parser();
            parser.AddArgParser(new ListenParser());
            parser.AddArgParser(new AppParser());
            parser.AddArgParser(new HelpParser());

            var reader = new ConfigReader(parser, new Validator());
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