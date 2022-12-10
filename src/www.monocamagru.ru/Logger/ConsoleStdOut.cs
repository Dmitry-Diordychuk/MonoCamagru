using System;

namespace MonoCamagru
{
class ConsoleStdOut : ILoggerOut
{
	public string Destination => "Console stdout";

	public void SetTextColor(LogColor color)
	{
		if (color == LogColor.yellow)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
		}
		else if (color == LogColor.red)
		{
			Console.ForegroundColor = ConsoleColor.Red;
		}
	}

	public void Write(string message)
	{
		Console.WriteLine(message);
		Console.ResetColor();
	}
}
}
