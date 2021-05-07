using System.IO;

using MFiles.VAF.EwerkExtensions.EWExceptions;

namespace MFiles.VAF.EwerkExtensions.ExtensionMethods
{
	/// <summary>
	/// Extension methods for working with <see cref="Stream"/> instances.
	/// </summary>
	/// <remarks>
	/// Contributed in 2021 by <a href="https://www.ewerk.com/innovation-hub/ecm" target="_new">EWERK Group</a>, Leipzig, Germany ||
	/// contact <a href="mailto:f.huth@ewerk.com" target="_new">Falk Huth</a> (Evangelist ECM) ||
	/// GitHub-Fork <a href="https://github.com/falk-huth-ewerk" target="_new">falk-huth-ewerk</a>
	/// </remarks>
	public static class EWStreamExtensionMethods
	{
		/// <summary>
		/// Extension method which reads the full content of the stream into an output byte array
		/// </summary>
		/// <param name="input">The stream where the extension method was created for</param>
		/// <returns></returns>
		public static byte[] EWReadFully(this Stream input)
		{
			// Sanity.
			if (null == input)
				throw new EWArgumentNullException(nameof(input));

			byte[] buffer = new byte[16 * 1024];
			using (MemoryStream ms = new MemoryStream())
			{
				int read;
				while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
				{
					ms.Write(buffer, 0, read);
				}
				return ms.ToArray();
			}
		}
	}
}
