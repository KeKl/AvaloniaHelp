using AvaloniaHelp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Provider
{
    /// <summary>
    ///     Defines the interface for a content provider.
    /// </summary>
    public interface IContentProvider
    {
        /// <summary>
        ///     Returns the content for the given topic.
        /// </summary>
        /// <param name="topic">
        ///     The topic.
        /// </param>
        /// <returns>
        ///     The content of the given topic.
        /// </returns>
        object GetContent(Topic topic);
    }
}