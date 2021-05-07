using System;
using System.Reflection;

using MFiles.VAF.EwerkExtensions.EWAttributes;

namespace MFiles.VAF.EwerkExtensions.ExtensionMethods
{
	/// <summary>
	/// Extensions for enums with attribute EWEnumDetailsAttribute
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public static class EWEnumExtensionMethods2
	{
		/// <summary>
		/// Get attribute field StringValue
		/// </summary>
		/// <param name="value">Enum entry</param>
		/// <returns>Field value</returns>
		public static string GetStringValue2(this Enum value)
		{
			if (null == value)
				throw new ArgumentNullException(nameof(value));

			// Get fieldinfo for this type
			FieldInfo fieldInfo = value.GetType()
									   .GetField(value.ToString());

			// Get the StringValue attributes
			EWEnumDetailsAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(EWEnumDetailsAttribute), false) as EWEnumDetailsAttribute[];

			// Return the first if there was a match.
			return attributes.Length > 0 ? attributes[0].StringValue : value.ToString();
		}

		/// <summary>
		/// Get attribute field Description
		/// </summary>
		/// <param name="value">Enum entry</param>
		/// <returns>Field value</returns>
		public static string GetDescription2(this Enum value)
		{
			if (null == value)
				throw new ArgumentNullException(nameof(value));

			// Get fieldinfo for this type
			FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

			// Get the StringValue attributes
			EWEnumDetailsAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(EWEnumDetailsAttribute), false) as EWEnumDetailsAttribute[];

			// Return the first if there was a match.
			return attributes.Length > 0 ? attributes[0].Description : string.Empty;
		}

		/// <summary>
		/// Get attribute field DisplayName
		/// </summary>
		/// <param name="value">Enum entry</param>
		/// <returns>Field value</returns>
		public static string GetDisplayName2(this Enum value)
		{
			if (null == value)
				throw new ArgumentNullException(nameof(value));

			// Get fieldinfo for this type
			FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

			// Get the StringValue attributes
			EWEnumDetailsAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(EWEnumDetailsAttribute), false) as EWEnumDetailsAttribute[];

			// Return the first if there was a match.
			return attributes.Length > 0 ? attributes[0].DisplayName : string.Empty;
		}

		/// <summary>
		/// Get attribute field Excluded
		/// </summary>
		/// <param name="value">Enum entry</param>
		/// <returns>Field value</returns>
		public static bool IsExcluded2(this Enum value)
		{
			if (null == value)
				throw new ArgumentNullException(nameof(value));

			// Get fieldinfo for this type
			FieldInfo fieldInfo = value.GetType().GetField(value.ToString());

			// Get the StringValue attributes
			EWEnumDetailsAttribute[] attributes = fieldInfo.GetCustomAttributes(typeof(EWEnumDetailsAttribute), false) as EWEnumDetailsAttribute[];

			// Return the first if there was a match.
			return attributes.Length > 0 && attributes[0].Excluded;
		}
	}
}
