using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MFiles.VAF.EwerkExtensions.EWExceptions.Tests
{
	/// <summary>
	/// Test methods for the class <see cref="EWArgumentNullException"/>
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[TestClass]
	public class EWArgumentNullExceptionTests
	{
		/// <summary>
		/// Constructor which sets the parameter name
		/// </summary>
		/// <param name="paramName">the parameter name</param>
		[TestMethod]
		[DataRow("ParamName")]
		[DataRow("")]
		[DataRow(null)]
		public void EWArgumentNullExceptionTestParamName(string paramName)
		{
			// Create object from data rows
			EWArgumentNullException ex = new EWArgumentNullException(paramName);

			// Assert object
			Assert.AreEqual(expected: paramName, actual: ex.ParamName);
		}

		/// <summary>
		/// Test if <see cref="ArgumentNullException"/> will be thrown
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException), AllowDerivedTypes = true)]
		public void EWArgumentNullExceptionTestThrowArgumentNullException()
		{
			throw new EWArgumentNullException("ParamName");
		}

		/// <summary>
		/// Test if <see cref="EWArgumentNullException"/> will be thrown
		/// </summary>
		[TestMethod]
		[ExpectedException(typeof(EWArgumentNullException), AllowDerivedTypes = false)]
		public void EWArgumentNullExceptionTestThrowEWArgumentNullException()
		{
			throw new EWArgumentNullException("ParamName");
		}

		/// <summary>
		/// Test if <see cref="IEwerkExtensionsException"/> will be thrown
		/// </summary>
		[TestMethod]
		public void EWArgumentNullExceptionTestTypeHierarchy()
		{
			// Create object from data rows
			EWArgumentNullException ex = new EWArgumentNullException("ParamName");

			// Assert type hierarchy of the exception
			Assert.IsInstanceOfType(ex, typeof(EWArgumentNullException));
			Assert.IsInstanceOfType(ex, typeof(ArgumentNullException));
			Assert.IsInstanceOfType(ex, typeof(ArgumentException));
			Assert.IsInstanceOfType(ex, typeof(ISerializable));
			Assert.IsInstanceOfType(ex, typeof(SystemException));
			Assert.IsInstanceOfType(ex, typeof(Exception));
			Assert.IsInstanceOfType(ex, typeof(_Exception));
			Assert.IsInstanceOfType(ex, typeof(IEwerkExtensionsException));
		}
	}
}
