using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Core
{
    /// <summary>
	/// 	Contains string extensions.
	/// </summary>
	public static class StringExtensions
    {
        /// <summary>
        /// 	Returns a value indicating whether a 
        /// 	specified substring occurs within this string.
        /// </summary>
        /// <param name="source">
        /// 	The source string
        /// </param>
        /// <param name="value">
        /// 	The string to seek.
        /// </param>
        /// <param name="comparison">
        /// 	One of the enumeration values that 
        /// 	specifies the rules for the search.
        /// </param>
        /// <returns>
        /// 	<b>True</b> if the value parameter occurs within this string, 
        /// 	or if value is the empty string (""); otherwise, <b>false</b>.
        /// </returns>
        public static bool Contains(this string source, string value, StringComparison comparison)
        {
            Contract.Requires(!string.IsNullOrEmpty(value));

            return source.IndexOf(value, comparison) >= 0;
        }
    }
}
