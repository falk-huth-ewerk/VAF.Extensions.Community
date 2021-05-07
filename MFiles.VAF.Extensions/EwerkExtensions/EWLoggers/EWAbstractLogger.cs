namespace MFiles.VAF.EwerkExtensions.EWLoggers
{
	/// <summary>
	/// Abstract event logger class which is implemented by MFEventLogger and later: other loggers (e.g. Log4Net)
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public abstract class EWAbstractLogger
	{
		/// <summary>
		/// Vault application for as class property
		/// </summary>
		protected readonly VaultApplicationBase App;

		/// <summary>
		/// Name of the event source as class property
		/// </summary>
		protected readonly string EventSource;

		/// <summary>
		/// Log level defaulted to INFO
		/// </summary>
		public int LogLevel = (int)EWLoggerEntryType.Info;

		/// <summary>
		/// Constructor initializing Vault application and Event source
		/// </summary>
		/// <param name="app">Vault application</param>
		/// <param name="eventSource">Name of the event source</param>
		public EWAbstractLogger(VaultApplicationBase app, string eventSource)
		{
			App = app;
			EventSource = eventSource;
		}

		/// <summary>
		/// Check if log level is visible according to the log level which is currently set
		/// </summary>
		/// <param name="type">Entry type</param>
		/// <returns>true if log entry can be shown, otherwise false</returns>
		protected bool IsLevelVisible(EWLoggerEntryType type) => (int) type <= LogLevel;

		/// <param name="message">Message to be shown</param>
		/// <param name="type">Entry type according to EWLoggerEntryType enum, e.g. EWLoggerEntryType.Error</param>
		/// <param name="eventID">Event ID specifying the entry</param>
		/// <param name="category">Category to be logged</param>
		/// <param name="rawData">Additional raw data as byte array</param>
		public abstract void WriteEntry(
			string message,
			EWLoggerEntryType type = EWLoggerEntryType.Error,
			int eventID = 0,
			short category = 0,
			byte[] rawData = null);

		/// <summary>
		/// Helper method for logging the start of a system method
		/// </summary>
		/// <param name="classFullName">Class name of the system method</param>
		/// <param name="methodName">Method name of the system method</param>
		public void StartSystemMethod(string classFullName, string methodName)
		{
			string message = $"Starting {classFullName}.{methodName} ...";
			int eventID = 0;
			short category = (short)0;
			byte[] rawData = null;

			WriteEntry(message, EWLoggerEntryType.Info, eventID, category, rawData);
		}

		/// <summary>
		/// Helper method for logging the end of a system method
		/// </summary>
		/// <param name="classFullName">Class name of the system method</param>
		/// <param name="methodName">Method name of the system method</param>
		public void EndSystemMethod(string classFullName, string methodName)
		{
			string message = $"Finished {classFullName}.{methodName} .";
			int eventID = 0;
			short category = (short)0;
			byte[] rawData = null;

			WriteEntry(message, EWLoggerEntryType.Info, eventID, category, rawData);
		}
	}

	/// <summary>
	/// Extension methods for MFLoggerEntryType
	/// </summary>
	public static partial class MFLoggerEntryTypeExtensionMethods
	{
		/// <summary>
		/// Helper method for getting the event ID from specified properties
		/// </summary>
		/// <param name="type">The EWLoggerType which should be used</param>
		/// <param name="facility12bit">Facility to be set</param>
		/// <param name="code16bit">Code to be set</param>
		/// <param name="isCustom">true, if it is custom</param>
		/// <returns>Calculated event ID</returns>
		public static int ToEventId(this EWLoggerEntryType type, uint facility12bit, uint code16bit, bool isCustom = true)
		{
			uint severity = (int)type <= (int)EWLoggerEntryType.Error
				? (uint)0b1100_0000_0000_0000_0000_0000_0000_0000
				: (int)type <= (int)EWLoggerEntryType.Warn
				? (uint)0b1000_0000_0000_0000_0000_0000_0000_0000
				: (int)type <= (int)EWLoggerEntryType.Info
				? (uint)0b0100_0000_0000_0000_0000_0000_0000_0000
				: (uint)0b0000_0000_0000_0000_0000_0000_0000_0000;
			uint facility = (facility12bit & 0b0000_0000_0000_0000_0000_1111_1111_1111) * 0b0000_0000_0000_0001_0000_0000_0000_0000;
			uint code = code16bit & 0b0000_0000_0000_0000_1111_1111_1111_1111;
			uint custom = isCustom
				? (uint)0b0010_0000_0000_0000_0000_0000_0000_0000
				: (uint)0b0000_0000_0000_0000_0000_0000_0000_0000;

			return (int) (severity | facility | code | custom);
		}
	}
}
