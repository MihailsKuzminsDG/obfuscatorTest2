namespace Dayton.Connection.Sx;

internal sealed class PerformContext : IPerformContext
{
	private readonly ISxSenderNotifier _sxSenderNotifier;

	public PerformContext(ISxSenderNotifier sxSenderNotifier)
	{
		_sxSenderNotifier = sxSenderNotifier;
	}

	public void LogMessage(LogLevel logLevel, Exception? exception, string format, params object[] args)
	{
	}

	public IProgressReporter GetProgressBar(string name, string? suffix = null)
	{
		return new ProgressReporter(_sxSenderNotifier, Guid.Empty, name);
	}

	private void SendLog(LogLevel logLevel, string message)
	{
	}

	public sealed class ProgressReporter : IProgressReporter
	{
		private readonly Guid _guid;
		private readonly string _name;
		private readonly ISxSenderNotifier _sxSenderNotifier;

		public ProgressReporter(ISxSenderNotifier sxSenderNotifier, Guid guid, string name)
		{
			_sxSenderNotifier = sxSenderNotifier;
			_guid = guid;
			_name = name;

			SetProgress(0d);
		}

		public void SetProgress(double progress)
		{
		}
	}
}
