using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Core
{
    public static class Extensions
    {
        /// <summary>
        ///     Searches the table of content for the given section header.
        /// </summary>
        /// <param name="sectionHeader">
        ///     The section header.
        /// </param>
        /// <returns>
        ///     All sections with the given header.
        /// </returns>
        public static IEnumerable<Section> FindInSectionsForHeader(this IEnumerable<Section> sections, string sectionHeader)
        {
            var result = new List<Section>();

            foreach (var section in sections)
                result.AddRange(Section.FindForHeader(section, sectionHeader));

            return result;
        }

    }
}
