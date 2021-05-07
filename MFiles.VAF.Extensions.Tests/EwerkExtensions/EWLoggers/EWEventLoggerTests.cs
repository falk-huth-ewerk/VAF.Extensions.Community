using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.EwerkExtensions.EWLoggers.Tests
{
	/// <summary>
	/// Test methods for the class <see cref="EWEventLogger"/>
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[TestClass]
	public class EWEventLoggerTests
	{
		///// <summary>
		///// Constant for the "Application" log name
		///// </summary>
		//public const string LOG_APPLICATION = "Application";

		///// <summary>
		///// Intenally storing event log instance
		///// </summary>
		//private readonly EventLog Log;

		///// <summary>
		///// Constructor initializing Vault application and Event source
		///// </summary>
		///// <param name="app">Vault application</param>
		///// <param name="eventSource">Name of the event source</param>
		//public EWEventLogger(VaultApplicationBase app, string eventSource) : base(app, eventSource)
		//{
		//	// Create the source, if it does not already exist.
		//	if (!EventLog.SourceExists(EventSource))
		//	{
		//		EventSourceCreationData sourceData = new EventSourceCreationData(source: EventSource, logName: LOG_APPLICATION);
		//		// TODO Add language-dependent message file for categories
		//		//if (File.Exists("CategoryResourceFile.mc"))
		//		//{
		//		//    sourceData.CategoryCount = 0;
		//		//    sourceData.CategoryResourceFile = "CategoryResourceFile.mc";
		//		//}
		//		EventLog.CreateEventSource(sourceData);
		//	}

		//	// Create an EventLog instance and assign its source.
		//	Log = new EventLog { Source = EventSource };
		//}

		///// <param name="message">Message to be shown</param>
		///// <param name="type">Entry type according to EWLoggerEntryType enum, e.g. EWLoggerEntryType.Error</param>
		///// <param name="eventID">Event ID specifying the entry</param>
		///// <param name="category">Category to be logged</param>
		///// <param name="rawData">Additional raw data as byte array</param>
		//public override void WriteEntry(
		//	string message,
		//	EWLoggerEntryType type = EWLoggerEntryType.Error,
		//	int eventID = 0,
		//	short category = 0,
		//	byte[] rawData = null
		//)
		//{
		//	if (IsLevelVisible(type))
		//		Log.WriteEntry(message, type.ToEventLogEntryType(), eventID, category, rawData);
		//}
	}

	public static partial class MFLoggerEntryTypeExtensionMethods
	{
		//public static EventLogEntryType ToEventLogEntryType(this EWLoggerEntryType type)
		//{
		//	return (int)type <= (int)EWLoggerEntryType.Error
		//		? EventLogEntryType.Error
		//		: (int)type <= (int)EWLoggerEntryType.Warn
		//		? EventLogEntryType.Warning
		//		: (int)type <= (int)EWLoggerEntryType.Info
		//		? EventLogEntryType.Information
		//		: EventLogEntryType.SuccessAudit;
		//}
	}
}
