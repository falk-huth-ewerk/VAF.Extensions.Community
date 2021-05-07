using MFiles.VAF.Common;
using MFiles.VAF.EwerkExtensions.EWExceptions;

namespace MFiles.VAF.EwerkExtensions.ExtensionMethods
{
	/// <summary>
	/// Extensions for enums with attribute MFEnumDetailsAttribute
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public static class EWExceptionExtensionMethods
	{
		public static string VaultName(this IEwerkExtensionsException ex) => SysUtils.VaultName;
		public static string VaultGuid(this IEwerkExtensionsException ex) => SysUtils.VaultGuid;
		public static string ApplicationName(this IEwerkExtensionsException ex) => ApplicationDefinition.Name;
		public static string ApplicationNameVersion(this IEwerkExtensionsException ex) => $"{ApplicationName(ex)} {ApplicationVersion(ex)}";
		public static string ApplicationVersion(this IEwerkExtensionsException ex) => ApplicationDefinition.Version?.ToString();
	}
}
