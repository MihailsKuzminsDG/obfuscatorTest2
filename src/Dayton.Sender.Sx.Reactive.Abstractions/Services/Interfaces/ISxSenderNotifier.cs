namespace Dayton.Connection.Sx;

public interface ISxSenderNotifier
{
	internal void SendProgressEntry(SxProgressEntryBase entry);

	internal void ClearItems(Guid guid);

	IObservable<SxProgressEntryBase> ProgressChanged(Guid guid);
}
