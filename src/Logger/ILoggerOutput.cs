namespace MonoCamagru.Logger
{
interface ILoggerOut
{
	string Destination { get; }
	void SetTextColor(LogColor color);
	void Write(string message);
}
}
