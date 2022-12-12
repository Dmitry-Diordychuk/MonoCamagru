using MonoCamagru.Logger;

namespace MonoCamagru.Application
{
class Application
{
	private Logger.Logger _logger;
	private Logger.Logger _stdout;

	private bool _isRunning;

	public Application(Logger.Logger logger)
	{
		_stdout = new Logger.Logger(new ConsoleStdOut());
		_logger = logger;

		if (_logger == null)
		{
			_logger = _stdout;
		}

		_stdout.Log($"Logger destination: {_logger.GetLoggerOutputDestination()}");

		_logger?.Log("Application settings done");
	}

	public void run()
	{
		_logger.Log("Application started up");

		_isRunning = true;
		while (_isRunning)
		{
			// _logger.Log("Application loop");
		}

		_logger.Log("Application shutdown");
	}
}
}
