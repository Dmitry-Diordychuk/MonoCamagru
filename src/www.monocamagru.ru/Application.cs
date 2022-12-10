using System;

namespace MonoCamagru
{
class Application
{
	private Logger _logger;
	private Logger _stdout;

	private bool _isRunning;

	public Application(Logger logger)
	{
		_stdout = new Logger(new ConsoleStdOut());
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
