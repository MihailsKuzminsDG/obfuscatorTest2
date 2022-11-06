namespace Dayton.Sender.Sx.Reactive.Tests.Services.PerformContextTests;

public sealed class GetProgressBarShould : PerformContextTestsBase
{
	[Fact]
	public void SetInitialProgress()
	{
		const string name = nameof(name);

		CreateClass()
			.GetProgressBar(name);
	}

	[Fact]
	public void SetProgress()
	{
		const string name = nameof(name);
		const double progress = 0.123d;

		var fixture = CreateClass()
			.GetProgressBar(name);

		fixture.SetProgress(progress);
	}
}