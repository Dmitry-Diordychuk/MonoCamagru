namespace fastcgi_server.ConfigReader.Validator;

interface IConfigValidator
{
    Config Config { get; }
    bool Validate(Dictionary<string, object> parameters);
}