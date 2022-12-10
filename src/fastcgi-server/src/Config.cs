namespace fastcgi_server
{
	struct Config
	{
		[IPValidation]
		public string IP;

		[PortValidation]
		public string Port;

		[AppFolderValidation]
		public string AppFolder;
	}

	[AttributeUsage(AttributeTargets.Field)]
	abstract class ValidationAttribute : Attribute
	{
		public abstract bool Validate(string value);
		
		protected void PrintError(string message)
		{
			Console.WriteLine(message + $" : {this}");
		}
	}

	class IPValidationAttribute : ValidationAttribute
	{
		public override bool Validate(string value)
		{
			string[] split = value.Split(new[] { '.' }, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

			if (split.Length != 4)
			{
				PrintError("IP address must be in dotted-decimal format");
				return false;
			}

			foreach (var part in split)
			{
				if (part.Length > 3)
				{
					PrintError("IP address must be in dotted-decimal format");
					return false;
				}

				foreach (var ch in part)
				{
					if (!char.IsDigit(ch))
					{
						PrintError("IP address must be in dotted-decimal format");
						return false;
					}
				}

				int decimalValue = Int32.Parse(part);
				if (decimalValue < 0 || decimalValue > 255)
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
		public override bool Validate(string value)
		{
			if (value.Length == 0 || value.Length > 5)
			{
				PrintError("A port number is a 16-bit unsigned integer, thus ranging from 0 to 65535.");
			}
			
			return true;
		}
	}

	class AppFolderValidationAttribute : ValidationAttribute
	{
		public override bool Validate(string value)
		{
			if (!Directory.Exists(value))
			{
				PrintError("Directory doesn't exits");
				return false;
			}
			
			return true;
		}
	}
}
