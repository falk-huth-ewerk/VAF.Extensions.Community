using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.EwerkExtensions.EWAttributes.Tests
{
	/// <summary>
	/// Test methods for the class <see cref="EWEnumDetailsAttribute"/>
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[TestClass]
	public class EWEnumDetailsAttributeTests
	{
		/// <summary>
		/// Test method for the constructor with 2 params
		/// </summary>
		/// <param name="stringValue">test value for StringValue</param>
		/// <param name="excluded">test value for Excluded</param>
		[TestMethod]
		[DataRow("StringValue1", false)]
		[DataRow("StringValue2", true)]
		[DataRow("", true)]
		[DataRow(null, false)]
		public void EWEnumDetailsAttributeTest2Params(string stringValue, bool excluded)
		{
			// Create objects from data rows
			EWEnumDetailsAttribute attrUsingDefault = new EWEnumDetailsAttribute(stringValue);
			EWEnumDetailsAttribute attrUsingExplicit = new EWEnumDetailsAttribute(stringValue, excluded);

			// Assert object initialized with default Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.StringValue);
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.Description);
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.DisplayName);
			Assert.AreEqual(expected: false, actual: attrUsingDefault.Excluded);

			// Assert object initialized with explicit Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.StringValue);
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.Description);
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.DisplayName);
			Assert.AreEqual(expected: excluded, actual: attrUsingExplicit.Excluded);
		}

		/// <summary>
		/// Test method for the constructor with 3 params
		/// </summary>
		/// <param name="stringValue">test value for StringValue</param>
		/// <param name="description">test value for Description</param>
		/// <param name="excluded">test value for Excluded</param>
		[TestMethod]
		[DataRow("StringValue1", "Description1", false)]
		[DataRow("StringValue2", "Description2", true)]
		[DataRow("", "Description3", true)]
		[DataRow(null, "Description4", false)]
		[DataRow("StringValue5", "", false)]
		[DataRow("StringValue6", null, true)]
		[DataRow("", "", true)]
		[DataRow("", null, false)]
		[DataRow(null, "", true)]
		[DataRow(null, null, false)]
		public void EWEnumDetailsAttributeTest3Params(string stringValue, string description, bool excluded)
		{
			// Create objects from data rows
			EWEnumDetailsAttribute attrUsingDefault = new EWEnumDetailsAttribute(stringValue, description);
			EWEnumDetailsAttribute attrUsingExplicit = new EWEnumDetailsAttribute(stringValue, description, excluded);

			// Assert object initialized with default Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.StringValue);
			Assert.AreEqual(expected: description, actual: attrUsingDefault.Description);
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.DisplayName);
			Assert.AreEqual(expected: false, actual: attrUsingDefault.Excluded);

			// Assert object initialized with explicit Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.StringValue);
			Assert.AreEqual(expected: description, actual: attrUsingExplicit.Description);
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.DisplayName);
			Assert.AreEqual(expected: excluded, actual: attrUsingExplicit.Excluded);
		}
		/// <summary>
		/// Test method for the constructor with 4 params
		/// </summary>
		/// <param name="stringValue">test value for StringValue</param>
		/// <param name="description">test value for Description</param>
		/// <param name="displayName">test value for DisplayName</param>
		/// <param name="excluded">test value for Excluded</param>
		[TestMethod]
		[DataRow("StringValue1", "Description1", "DisplayName1", false)]
		[DataRow("StringValue2", "Description2", "DisplayName2", true)]
		[DataRow("", "Description3", "DisplayName3", true)]
		[DataRow(null, "Description4", "DisplayName4", false)]
		[DataRow("StringValue5", "", "DisplayName5", false)]
		[DataRow("StringValue6", null, "DisplayName6", true)]
		[DataRow("", "", "DisplayName7", true)]
		[DataRow("", null, "DisplayName8", false)]
		[DataRow(null, "", "DisplayName9", true)]
		[DataRow(null, null, "DisplayName10", false)]
		[DataRow("", "Description11", "", true)]
		[DataRow(null, "Description12", "", false)]
		[DataRow("StringValue13", "", "", false)]
		[DataRow("StringValue14", null, "", true)]
		[DataRow("", "", "", true)]
		[DataRow("", null, "", false)]
		[DataRow(null, "", "", true)]
		[DataRow(null, null, "", false)]
		[DataRow("", "Description15", null, true)]
		[DataRow(null, "Description16", null, false)]
		[DataRow("StringValue17", "", null, false)]
		[DataRow("StringValue18", null, null, true)]
		[DataRow("", "", null, true)]
		[DataRow("", null, null, false)]
		[DataRow(null, "", null, true)]
		[DataRow(null, null, null, false)]
		public void EWEnumDetailsAttributeTest4Params(string stringValue, string description, string displayName, bool excluded)
		{
			// Create objects from data rows
			EWEnumDetailsAttribute attrUsingDefault = new EWEnumDetailsAttribute(stringValue, description, displayName);
			EWEnumDetailsAttribute attrUsingExplicit = new EWEnumDetailsAttribute(stringValue, description, displayName, excluded);

			// Assert object initialized with default Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingDefault.StringValue);
			Assert.AreEqual(expected: description, actual: attrUsingDefault.Description);
			Assert.AreEqual(expected: displayName, actual: attrUsingDefault.DisplayName);
			Assert.AreEqual(expected: false, actual: attrUsingDefault.Excluded);

			// Assert object initialized with explicit Excluded value
			Assert.AreEqual(expected: stringValue, actual: attrUsingExplicit.StringValue);
			Assert.AreEqual(expected: description, actual: attrUsingExplicit.Description);
			Assert.AreEqual(expected: displayName, actual: attrUsingExplicit.DisplayName);
			Assert.AreEqual(expected: excluded, actual: attrUsingExplicit.Excluded);
		}
	}
}