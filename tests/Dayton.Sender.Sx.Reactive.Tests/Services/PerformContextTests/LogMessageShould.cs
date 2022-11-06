namespace Dayton.Sender.Sx.Reactive.Tests.Services.PerformContextTests;

public sealed class LogMessageShould : PerformContextTestsBase
{
	[Fact]
	public void SendFormattedMessage()
	{
		const int id = 123;
		const string message = nameof(message);
		const LogLevel logLevel = LogLevel.Information;

		CreateClass()
			.LogMessage(logLevel, null,  "This {Id} is {Message}", id, message);
	}
	
	[Fact]
	public void SendFormattedMessageWithException()
	{
		const int id = 123;
		const string message = nameof(message);
		var exception = new Exception("error occurred");
		const LogLevel logLevel = LogLevel.Information;

		CreateClass()
			.LogMessage(logLevel, exception,  "This {Id} is {Message}", id, message);
	}
}
