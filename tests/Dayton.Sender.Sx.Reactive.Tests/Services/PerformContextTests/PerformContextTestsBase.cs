namespace Dayton.Sender.Sx.Reactive.Tests.Services.PerformContextTests;

public abstract class PerformContextTestsBase
{
	protected Mock<ISxSenderNotifier> MockSxNotifier { get; } = new();

	internal PerformContext CreateClass() =>
		new(MockSxNotifier.Object);

	protected void VerifyNoOtherCalls()
	{
		MockSxNotifier.VerifyNoOtherCalls();
	}
}