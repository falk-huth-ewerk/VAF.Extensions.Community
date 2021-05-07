using System;

namespace MFiles.VAF.EwerkExtensions.EWExceptions
{
	/// <summary>
	/// M-Files VAF Exception that indicates that the specified argument is null = implementation of IMFException for ArgumentNummException
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public class EWArgumentNullException : ArgumentNullException, IEwerkExtensionsException
	{
		/// <summary>
		/// Constructor which sets the parameter name
		/// </summary>
		/// <param name="paramName">the parameter name</param>
		public EWArgumentNullException(string paramName) : base(paramName) { }
	}
}
