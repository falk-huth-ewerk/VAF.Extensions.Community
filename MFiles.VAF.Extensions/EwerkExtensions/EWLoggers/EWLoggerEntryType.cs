using MFiles.VAF.EwerkExtensions.EWAttributes;

namespace MFiles.VAF.EwerkExtensions.EWLoggers
{
	/// <summary>
	/// Enum for log entry types
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public enum EWLoggerEntryType : int
	{
		/// <summary>
		/// Logging off
		/// </summary>
		[EWEnumDetails("Off", "Logging off")]
		Off = 0,

		/// <summary>
		/// Fatal error
		/// </summary>
		[EWEnumDetails("Fatal", "Fatal error")]
		Fatal = 100,

		/// <summary>
		/// Standard error
		/// </summary>
		[EWEnumDetails("Error", "Standard error")]
		Error = 200,

		/// <summary>
		/// Warning
		/// </summary>
		[EWEnumDetails("Warn", "Warning")]
		Warn = 300,

		/// <summary>
		/// Info message
		/// </summary>
		[EWEnumDetails("Info", "Info message")]
		Info = 400,

		/// <summary>
		/// Only debug message
		/// </summary>
		[EWEnumDetails("Debug", "Only Debug meesage")]
		Debug = 500,

		/// <summary>
		/// Trace level for deeper debugging
		/// </summary>
		[EWEnumDetails("Trace", "Trace level for deeper debugging")]
		Trace = 600,

		/// <summary>
		/// All possible entries
		/// </summary>
		[EWEnumDetails("All", "All possible entries")]
		All = int.MaxValue
	}
}
