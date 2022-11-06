namespace Dayton.Connection.Sx;

internal interface IPerformContext
{
	void LogMessage(LogLevel logLevel, Exception? exception, string format, params object[] args);

	IProgressReporter GetProgressBar(string name, string? suffix = null);
}
