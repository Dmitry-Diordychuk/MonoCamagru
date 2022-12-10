namespace MonoCamagru
{
class Logger
{
	private ILoggerOut _output;

	public Logger(ILoggerOut output)
	{
		_output = output;
	}

	public string GetLoggerOutputDestination()
	{
		return _output.Destination;
	}

	public void Log(string message)
	{
		_output.SetTextColor(LogColor.black);
		_output.Write("[Message]: " + message);
	}

	public void LogWarning(string message)
	{
		_output.SetTextColor(LogColor.yellow);
		_output.Write("[Warning]: " + message);
	}

	public void LogError(string message)
	{
		_output.SetTextColor(LogColor.red);
		_output.Write("[!Error!]: " + message);
	}
}
}
