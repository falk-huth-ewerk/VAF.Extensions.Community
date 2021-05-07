using System;

namespace MFiles.VAF.EwerkExtensions.EWAttributes
{
	/// <summary>
	/// Additional attribute fields for enums: StringValue, Description, DisplayName, Excluded (to be used by UI components)
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	[AttributeUsage(AttributeTargets.Field)]
	public class EWEnumDetailsAttribute : Attribute
	{
		/// <summary>
		/// Constructor initializing StringValue, Description and DisplayName from parameter stringValue
		/// </summary>
		/// <param name="stringValue">string value to be set</param>
		/// <param name="excluded">true if value should be excluded in lists, otherwise (Default) false</param>
		public EWEnumDetailsAttribute(string stringValue, bool excluded = false)
		{
			StringValue = stringValue;
			Description = stringValue;
			DisplayName = stringValue;
			Excluded = excluded;
		}

		/// <summary>
		/// Constructor initializing StringValue and DisplayName from parameter stringValue
		/// </summary>
		/// <param name="stringValue">string value to be set</param>
		/// <param name="description">description to be set</param>
		/// <param name="excluded">true if value should be excluded in lists, otherwise (Default) false</param>
		public EWEnumDetailsAttribute(string stringValue, string description, bool excluded = false)
		{
			StringValue = stringValue;
			Description = description;
			DisplayName = stringValue;
			Excluded = excluded;
		}

		/// <summary>
		/// Constructor initializing all members
		/// </summary>
		/// <param name="stringValue">string value to be set</param>
		/// <param name="description">description to be set</param>
		/// <param name="displayName">display name to be set</param>
		/// <param name="excluded">true if value should be excluded in lists, otherwise (Default) false</param>
		public EWEnumDetailsAttribute(string stringValue, string description, string displayName, bool excluded = false)
		{
			StringValue = stringValue;
			Description = description;
			DisplayName = displayName;
			Excluded = excluded;
		}

		/// <summary>
		/// String value of this attribute
		/// </summary>
		public string StringValue { get; set; }

		/// <summary>
		/// Description field of this attribute
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// Display name of this attribute
		/// </summary>
		public string DisplayName { get; set; }

		/// <summary>
		/// Flag if this enum entry should be excluded
		/// </summary>
		public bool Excluded { get; set; }
	}
}
