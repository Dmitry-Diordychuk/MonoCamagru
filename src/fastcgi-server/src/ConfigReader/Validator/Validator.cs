using System.Reflection;

namespace fastcgi_server;

class Validator : IConfigValidator
{
    public Config Config { get; private set; }

    public bool Validate(Dictionary<string, object> parameters)
    {
        object result = Config;
        Type configType = typeof(Config);

        foreach (var p in parameters)
        {
            foreach (FieldInfo field in configType.GetFields(BindingFlags.Public | BindingFlags.Instance))
            {
                if (field.Name.ToLower() != p.Key.ToLower())
                {
                    continue;
                }
                    
                object[] attributes = field.GetCustomAttributes(false);
                foreach (ValidationAttribute attr in attributes)
                {
                    if (attr.Validate(p.Value))
                        field.SetValue(result, p.Value);
                    else
                        return false;
                }
            }
        }

        Config = (Config)result;
        return true;
    }
}