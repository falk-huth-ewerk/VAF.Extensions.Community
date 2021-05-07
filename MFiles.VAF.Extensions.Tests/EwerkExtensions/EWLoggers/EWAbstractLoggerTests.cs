using MFiles.VAF.Common;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.EwerkExtensions.EWLoggers.Tests
{
	/// <summary>
	/// Test methods for the class <see cref="EWAbstractLogger"/>
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[TestClass]
	public class EWAbstractLoggerTests
	{
		/// <summary>
		/// storing initialized VaultApplication object
		/// </summary>
		private VaultApplicationBase _app;

		/// <summary>
		/// Initialize the test method
		/// </summary>
		[TestInitialize]
		public void EWAbstractLoggerInit() => _app = new VaultApplicationBase() { };

		/// <summary>
		/// Test method for the constructor
		/// </summary>
		/// <param name="eventSource">test value for EventSource</param>
		[TestMethod]
		[DataRow("Event Source")]
		[DataRow("")]
		[DataRow(null)]
		public void EWAbstractLoggerTestConstructor(string eventSource)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, eventSource);

			// Check parameters set
			Assert.AreEqual(expected: _app.ApplicationRunningStatus, actual: logger.LastVaultApplicationBase.ApplicationRunningStatus);
			Assert.AreEqual(expected: eventSource, actual: logger.LastEventSource);

			// Check parameters stored
			Assert.AreEqual(expected: _app.ApplicationRunningStatus, actual: logger.SavedVaultApplicationBase.ApplicationRunningStatus);
			Assert.AreEqual(expected: eventSource, actual: logger.SavedEventSource);

			// Check initial log level
			Assert.AreEqual(expected: (int) EWLoggerEntryType.Info, actual: logger.LogLevel);
		}

		/// <summary>
		/// Test method <see cref="IsLevelVisible"/>
		/// </summary>
		/// <param name="logLevel">test value for LogLevel</param>
		/// <param name="type">test value for Type</param>
		/// <param name="visible">expected result</param>
		[TestMethod]
		// LogLevel: Off
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Fatal, false)]
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Error, false)]
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Warn, false)]
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Info, false)]
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Debug, false)]
		[DataRow(EWLoggerEntryType.Off, EWLoggerEntryType.Trace, false)]
		// LogLevel: Fatal
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Error, false)]
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Warn, false)]
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Info, false)]
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Debug, false)]
		[DataRow(EWLoggerEntryType.Fatal, EWLoggerEntryType.Trace, false)]
		// LogLevel: Error
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Warn, false)]
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Info, false)]
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Debug, false)]
		[DataRow(EWLoggerEntryType.Error, EWLoggerEntryType.Trace, false)]
		// LogLevel: Warn
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Warn, true)]
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Info, false)]
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Debug, false)]
		[DataRow(EWLoggerEntryType.Warn, EWLoggerEntryType.Trace, false)]
		// LogLevel: Info
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Warn, true)]
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Info, true)]
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Debug, false)]
		[DataRow(EWLoggerEntryType.Info, EWLoggerEntryType.Trace, false)]
		// LogLevel: Debug
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Warn, true)]
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Info, true)]
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Debug, true)]
		[DataRow(EWLoggerEntryType.Debug, EWLoggerEntryType.Trace, false)]
		// LogLevel: Trace
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Warn, true)]
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Info, true)]
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Debug, true)]
		[DataRow(EWLoggerEntryType.Trace, EWLoggerEntryType.Trace, true)]
		// LogLevel: All
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Fatal, true)]
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Error, true)]
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Warn, true)]
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Info, true)]
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Debug, true)]
		[DataRow(EWLoggerEntryType.All, EWLoggerEntryType.Trace, true)]
		protected void IsLevelVisibleTest(EWLoggerEntryType logLevel, EWLoggerEntryType type, bool visible)
		{
			// initialize logger and set log level
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");
			logger.LogLevel = (int) logLevel;

			// check visibility
			Assert.AreEqual(expected: visible, actual: logger.IsLevelVisiblePublic(type));
		}

		/// <summary>
		/// Test method <see cref="WriteEntry(string)"/> with 1 parameter
		/// </summary>
		/// <param name="message">Test value for Message</param>
		[TestMethod]
		[DataRow("Message1")]
		[DataRow("")]
		[DataRow(null)]
		public void WriteEntryTest1Param(string message)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.WriteEntry(message);

			// Check results
			Assert.AreEqual(expected: message, actual: logger.LastMessage);
			Assert.AreEqual(expected: EWLoggerEntryType.Error, actual: logger.LastType);
			Assert.AreEqual(expected: 0, actual: logger.LastEventID);
			Assert.AreEqual(expected: (short) 0, actual: (short) logger.LastCategory);
			Assert.AreEqual(expected: null, actual: logger.LastRawData);
		}

		/// <summary>
		/// Test method <see cref="WriteEntry(string, EWLoggerEntryType)"/> with 2 parameters
		/// </summary>
		/// <param name="message">Test value for Message</param>
		/// <param name="type">Test value for Type</param>
		[TestMethod]
		[DataRow("Message1", EWLoggerEntryType.Error)]
		[DataRow("", EWLoggerEntryType.Warn)]
		[DataRow(null, EWLoggerEntryType.Trace)]
		public void WriteEntryTest2Params(
				string message,
				EWLoggerEntryType type)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.WriteEntry(message, type);

			// Check results
			Assert.AreEqual(expected: message, actual: logger.LastMessage);
			Assert.AreEqual(expected: type, actual: logger.LastType);
			Assert.AreEqual(expected: 0, actual: logger.LastEventID);
			Assert.AreEqual(expected: (short) 0, actual: (short) logger.LastCategory);
			Assert.AreEqual(expected: null, actual: logger.LastRawData);
		}

		/// <summary>
		/// Test method <see cref="WriteEntry(string, EWLoggerEntryType, int)"/> with 3 parameters
		/// </summary>
		/// <param name="message">Test value for Message</param>
		/// <param name="type">Test value for Type</param>
		/// <param name="eventID">Test value for EventID</param>
		[TestMethod]
		[DataRow("Message1", EWLoggerEntryType.Error, 1)]
		[DataRow("", EWLoggerEntryType.Warn, 3)]
		[DataRow(null, EWLoggerEntryType.Trace, 5)]
		public void WriteEntryTest3Params(
				string message,
				EWLoggerEntryType type,
				int eventID)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.WriteEntry(message, type, eventID);

			// Check results
			Assert.AreEqual(expected: message, actual: logger.LastMessage);
			Assert.AreEqual(expected: type, actual: logger.LastType);
			Assert.AreEqual(expected: eventID, actual: logger.LastEventID);
			Assert.AreEqual(expected: (short) 0, actual: (short) logger.LastCategory);
			Assert.AreEqual(expected: null, actual: logger.LastRawData);
		}

		/// <summary>
		/// Test method <see cref="WriteEntry(string, EWLoggerEntryType, int, short)"/> with 4 parameters
		/// </summary>
		/// <param name="message">Test value for Message</param>
		/// <param name="type">Test value for Type</param>
		/// <param name="eventID">Test value for EventID</param>
		/// <param name="category">Test value for Category</param>
		[TestMethod]
		[DataRow("Message1", EWLoggerEntryType.Error, 1, (short) 2)]
		[DataRow("", EWLoggerEntryType.Warn, 3, (short) 4)]
		[DataRow(null, EWLoggerEntryType.Trace, 5, (short) 6)]
		public void WriteEntryTest4Params(
				string message,
				EWLoggerEntryType type,
				int eventID,
				short category)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.WriteEntry(message, type, eventID, category);

			// Check results
			Assert.AreEqual(expected: message, actual: logger.LastMessage);
			Assert.AreEqual(expected: type, actual: logger.LastType);
			Assert.AreEqual(expected: eventID, actual: logger.LastEventID);
			Assert.AreEqual(expected: category, actual: (short) logger.LastCategory);
			Assert.AreEqual(expected: null, actual: logger.LastRawData);
		}

		/// <summary>
		/// Test method <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/> with 5 parameters
		/// </summary>
		/// <param name="message">Test value for Message</param>
		/// <param name="type">Test value for Type</param>
		/// <param name="eventID">Test value for EventID</param>
		/// <param name="category">Test value for Category</param>
		/// <param name="rawData">Test value for RawData</param>
		[TestMethod]
		[DataRow("Message1", EWLoggerEntryType.Error, 1, (short) 2, new byte[] { 1, 2, 3 })]
		[DataRow("", EWLoggerEntryType.Warn, 3, (short) 4, null)]
		[DataRow(null, EWLoggerEntryType.Trace, 5, (short) 6, new byte[] { 1, 2, 3 })]
		public void WriteEntryTest5Params(
				string message,
				EWLoggerEntryType type,
				int eventID,
				short category,
				byte[] rawData)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.WriteEntry(message, type, eventID, category, rawData);

			// Check results
			Assert.AreEqual(expected: message, actual: logger.LastMessage);
			Assert.AreEqual(expected: type, actual: logger.LastType);
			Assert.AreEqual(expected: eventID, actual: logger.LastEventID);
			Assert.AreEqual(expected: category, actual: (short) logger.LastCategory);
			Assert.AreEqual(expected: rawData, actual: logger.LastRawData);
		}

		/// <summary>
		/// Test method for <see cref="StartSystemMethod(string, string)"/>
		/// </summary>
		/// <param name="classFullName">Test value of ClassFullName</param>
		/// <param name="methodName">Test value of MethodName</param>
		[TestMethod]
		[DataRow("ClassFullName1", "MethodName1")]
		[DataRow("ClassFullName2", "")]
		[DataRow("ClassFullName3", null)]
		[DataRow("", "MethodName4")]
		[DataRow(null, "MethodName5")]
		[DataRow("", "")]
		[DataRow("", null)]
		[DataRow(null, "")]
		[DataRow(null, null)]
		public void StartSystemMethodTest(string classFullName, string methodName)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.StartSystemMethod(classFullName, methodName);

			// Check results
			StringAssert.Contains(value: logger.LastMessage, substring: "Start");
			StringAssert.Contains(value: logger.LastMessage, substring: classFullName ?? "");
			StringAssert.Contains(value: logger.LastMessage, substring: methodName ?? "");
			Assert.AreEqual(expected: EWLoggerEntryType.Info, actual: logger.LastType);
			Assert.AreEqual(expected: 0, actual: logger.LastEventID);
			Assert.AreEqual(expected: (short) 0, actual: logger.LastCategory);
			Assert.IsNull(value: logger.LastRawData);
		}

		/// <summary>
		/// Test method for <see cref="EndSystemMethod(string, string)"/>
		/// </summary>
		/// <param name="classFullName">Test value of ClassFullName</param>
		/// <param name="methodName">Test value of MethodName</param>
		[TestMethod]
		[DataRow("ClassFullName1", "MethodName1")]
		[DataRow("ClassFullName2", "")]
		[DataRow("ClassFullName3", null)]
		[DataRow("", "MethodName4")]
		[DataRow(null, "MethodName5")]
		[DataRow("", "")]
		[DataRow("", null)]
		[DataRow(null, "")]
		[DataRow(null, null)]
		public void EndSystemMethodTest(string classFullName, string methodName)
		{
			// initialize logger
			EWTestLoggerImpl logger = new EWTestLoggerImpl(_app, "EventSource");

			// write log message
			logger.EndSystemMethod(classFullName, methodName);

			// Check results
			StringAssert.Contains(value: logger.LastMessage, substring: "Finish");
			StringAssert.Contains(value: logger.LastMessage, substring: classFullName ?? "");
			StringAssert.Contains(value: logger.LastMessage, substring: methodName ?? "");
			Assert.AreEqual(expected: EWLoggerEntryType.Info, actual: logger.LastType);
			Assert.AreEqual(expected: 0, actual: logger.LastEventID);
			Assert.AreEqual(expected: (short) 0, actual: logger.LastCategory);
			Assert.IsNull(value: logger.LastRawData);
		}
	}

	/// <summary>
	/// Pseudo implementation to test abstact class
	/// </summary>
	public class EWTestLoggerImpl : EWAbstractLogger
	{
		/// <summary>
		/// storing parameter message of last call of <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/>
		/// </summary>
		public string LastMessage;

		/// <summary>
		/// storing parameter type of last call of <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/>
		/// </summary>
		public EWLoggerEntryType LastType;

		/// <summary>
		/// storing parameter eventID of last call of <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/>
		/// </summary>
		public int LastEventID;

		/// <summary>
		/// storing parameter category of last call of <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/>
		/// </summary>
		public short LastCategory;

		/// <summary>
		/// storing parameter rawData of last call of <see cref="WriteEntry(string, EWLoggerEntryType, int, short, byte[])"/>
		/// </summary>
		public byte[] LastRawData;

		/// <summary>
		/// storing parameter app of last call of the constructor of <see cref="EWTestLoggerImpl"/>
		/// </summary>
		public VaultApplicationBase LastVaultApplicationBase;

		/// <summary>
		/// storing parameter eventSource of last call of the constructor of <see cref="EWTestLoggerImpl"/>
		/// </summary>
		public string LastEventSource;

		/// <summary>
		/// getting the internal saved App
		/// </summary>
		public VaultApplicationBase SavedVaultApplicationBase => this.App;

		/// <summary>
		/// getting the internal saved EventSourcce
		/// </summary>
		public string SavedEventSource => this.EventSource;

		/// <summary>
		/// Makes method <see cref="IsLevelVisible(EWLoggerEntryType)"/> visible
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public bool IsLevelVisiblePublic(EWLoggerEntryType type) => IsLevelVisible(type);

		/// <inheritdoc/>
		public EWTestLoggerImpl(VaultApplicationBase app, string eventSource) : base(app, eventSource)
		{
			LastVaultApplicationBase = app;
			LastEventSource = eventSource;
		}

		/// <inheritdoc/>
		public override void WriteEntry(
			string message,
			EWLoggerEntryType type = EWLoggerEntryType.Error,
			int eventID = 0,
			short category = 0,
			byte[] rawData = null)
		{
			LastMessage = message;
			LastType = type;
			LastEventID = eventID;
			LastCategory = category;
			LastRawData = rawData;
		}
	}
}
