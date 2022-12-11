namespace fastcgi_server.ConfigReader.Validator;

[AttributeUsage(AttributeTargets.Field)]
abstract class ValidationAttribute : Attribute
{
    public abstract bool Validate(object value);
		
    protected void PrintError(string message)
    {
        Console.WriteLine(message + $" : {this}");
    }
}

class IPValidationAttribute : ValidationAttribute
{
    public override bool Validate(object value)
    {
        int[] ip = (int[])value;
        
        if (ip.Length != 4)
        {
            PrintError("IP address must be in dotted-decimal format");
            return false;
        }

        foreach (int part in ip)
        {
            if (part < 0 || part > 255)
            {
                PrintError("IP address must be in dotted-decimal format");
                return false;
            }
        }
        return true;
    }
}

class PortValidationAttribute : ValidationAttribute
{
    public override bool Validate(object value)
    {
        int port = (int)value;
        
        if (port < 0 || port > 65535)
        {
            PrintError("A port number is a 16-bit unsigned integer, thus ranging from 0 to 65535.");
            return false;
        }
			
        return true;
    }
}

class AppFolderValidationAttribute : ValidationAttribute
{
    public override bool Validate(object value)
    {
        
        if (!Directory.Exists((string)value))
        {
            PrintError("Directory doesn't exits");
            return false;
        }
			
        return true;
    }
}