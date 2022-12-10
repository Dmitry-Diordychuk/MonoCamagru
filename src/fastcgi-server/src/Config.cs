using System;

namespace FastCgi
{
	struct Config
	{
		[IPValidation(typeof(string))]
		public string IP;

		[PortValidation(typeof(string))]
		public string Port;

		[AppFolderValidation(typeof(string))]
		public string AppFolder;
	}

	[AttributeUsage(AttributeTargets.Field)]
	abstract class ValidationAttribute : Attribute
	{
		public Type Type { get => _type; }
		protected Type _type;

		public abstract bool TryValidate(string name, string value, out object result);
	}

	class IPValidationAttribute : ValidationAttribute
	{
		public string IP { get; } = "";

		public IPValidationAttribute(Type type)
		{
			_type = type;
		}

		public override bool TryValidate(string name, string value, out object result)
		{
			result = false;
			if (name != "ip")
			{
				return false;
			}

			result = value;
			return true;
		}
	}

	class PortValidationAttribute : ValidationAttribute
	{
		public string Port { get; } = "";

		public PortValidationAttribute(Type type)
		{
			_type = type;
		}

		public override bool TryValidate(string name, string value, out object result)
		{
			result = false;
			if (name != "port")
			{
				return false;
			}

			result = value;
			return true;
		}
	}

	class AppFolderValidationAttribute : ValidationAttribute
	{
		public string AppFolder { get; } = "";

		public AppFolderValidationAttribute(Type type)
		{
			_type = type;
		}

		public override bool TryValidate(string name, string value, out object result)
		{
			result = false;
			if (name != "--app")
			{
				return false;
			}

			result = value;
			return true;
		}
	}
}
