using System.Reflection;
using FastCgi;
using fastcgi_server.Parser;

namespace fastcgi_server
{
    internal abstract class Program
    {
        public static int Main(string[] args)
        {
            var parser = new ConfigParser();
            parser.AddArgParser(new ListenParser());
            parser.AddArgParser(new AppParser());
            parser.AddArgParser(new HelpParser());

            var reader = new ConfigReader(parser, new ConfigValidator());
            if (reader.TryRead(args, out Config config))
            {
                Console.WriteLine(config.IP);
                Console.WriteLine(config.Port);
                Console.WriteLine(config.AppFolder);

                return 0;
            }
            return -1;
        }
    }

    interface IConfigValidator
    {
        Config Config { get; }
        bool Validate(Dictionary<string, string> parameters);
    }

    class ConfigValidator : IConfigValidator
    {
        public Config Config { get ; }

        public bool Validate(Dictionary<string, string> parameters)
        {
            Type configType = typeof(Config);

            foreach (var p in parameters)
            {
                foreach (FieldInfo field in configType.GetFields())
                {
                    object[] attributes = field.GetCustomAttributes(false);

                    foreach (Attribute attr in attributes)
                    {
                        if (attr is ValidationAttribute validationAttribute)
                            if (validationAttribute.TryValidate(p.Key, p.Value, out var result))
                            {
                                Console.WriteLine(result);
                                field.SetValue(Config, Convert.ChangeType(result, validationAttribute.Type));
                            }
                    }
                }
            }
            return true;
        }
    }
}