using System;
using System.Collections.Generic;
using System.Linq;

using MFiles.VAF.EwerkExtensions.ExtensionMethods;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.EwerkExtensions.EWLoggers.Tests
{
	/// <summary>
	/// Test methods for the enum <see cref="EWLoggerEntryType"/>
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[TestClass]
	public class EWLoggerEntryTypeTests
	{
		/// <summary>
		/// Constant for number of entries
		/// </summary>
		public const int ENTRY_COUNT = 8;

		/// <summary>
		/// Test method for the constructor with 2 params
		/// </summary>
		/// <param name="stringValue">test value for StringValue</param>
		/// <param name="excluded">test value for Excluded</param>
		[TestMethod]
		public void EWLoggerEntryTypeTestAllEntries()
		{
			// Loop all enum entries
			List<EWLoggerEntryType> allEntries = Enum.GetValues(typeof(EWLoggerEntryType)).Cast<EWLoggerEntryType>().ToList();
			foreach (EWLoggerEntryType entry in allEntries)
			{
				// Check if all entries are set
				Assert.IsFalse(string.IsNullOrEmpty(entry.GetStringValue()));
				Assert.IsFalse(string.IsNullOrEmpty(entry.GetDescription()));
				Assert.IsFalse(string.IsNullOrEmpty(entry.GetDisplayName()));
				Assert.IsFalse(entry.IsExcluded());
			}

			// Check count of entries
			Assert.AreEqual(expected: ENTRY_COUNT, actual: allEntries.Count);
		}

		/// <summary>
		/// Test method for the constructor with 2 params
		/// </summary>
		/// <param name="entry">test value for the enum entry</param>
		/// <param name="value">test value for the int value of the enum</param>
		/// <param name="stringValue">test value for StringValue</param>
		[TestMethod]
		[DataRow(EWLoggerEntryType.Off, 0, "Off")]
		[DataRow(EWLoggerEntryType.Fatal, 100, "Fatal")]
		[DataRow(EWLoggerEntryType.Error, 200, "Error")]
		[DataRow(EWLoggerEntryType.Warn, 300, "Warn")]
		[DataRow(EWLoggerEntryType.Info, 400, "Info")]
		[DataRow(EWLoggerEntryType.Debug, 500, "Debug")]
		[DataRow(EWLoggerEntryType.Trace, 600, "Trace")]
		[DataRow(EWLoggerEntryType.All, int.MaxValue, "All")]
		public void EWLoggerEntryTypeTestWithAttributes(EWLoggerEntryType entry, int value, string stringValue)
		{
			// Assert enum values and attribute values
			Assert.AreEqual(expected: value, actual: (int) entry);
			Assert.AreEqual(expected: stringValue, actual: entry.GetStringValue());
			Assert.IsFalse(string.IsNullOrEmpty(entry.GetDescription()));
			Assert.AreNotEqual(notExpected: stringValue, actual: entry.GetDescription());
			Assert.AreEqual(expected: stringValue, actual: entry.GetDisplayName());
		}
	}
}
