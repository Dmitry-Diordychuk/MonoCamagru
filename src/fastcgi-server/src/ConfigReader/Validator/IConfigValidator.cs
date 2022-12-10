namespace fastcgi_server;

interface IConfigValidator
{
    Config Config { get; }
    bool Validate(Dictionary<string, object> parameters);
}