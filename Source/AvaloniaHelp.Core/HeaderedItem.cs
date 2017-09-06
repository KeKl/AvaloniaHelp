using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Core
{
    /// <summary>
    ///     The headered item.
    /// </summary>
    public abstract class HeaderedItem
    {
        /// <summary>
        ///     Creates a new instance of <see cref="HeaderedItem"/>. 
        /// </summary>
        /// <param name="header">
        ///     The header of the <see cref="HeaderedItem"/>.
        /// </param>
        /// <param name="topic">
        ///     The associated topic.
        /// </param>
        public HeaderedItem(string header, Topic topic)
            : this(header)
        {
            Topic = topic;
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Section"/>. 
        /// </summary>
        /// <param name="header">
        ///     The header of the <see cref="Section"/>.
        /// </param>
        public HeaderedItem(string header)
            : this()
        {
            Header = header;
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Section"/>. 
        /// </summary>
        public HeaderedItem()
        {
        }
        
        /// <summary>
        ///     The header.
        /// </summary>
        public string Header { get; protected set; }

        /// <summary>
        ///     The associated topic.
        /// </summary>
        public Topic Topic { get; set; }

        /// <summary>
        ///     Returns a string that represents the current <see cref="HeaderedItem"/>.
        /// </summary>
        /// <returns>
        ///     A string that represents the current <see cref="HeaderedItem"/>.
        /// </returns>
        public override string ToString()
        {
            return $"Header: {Header}, Topic Keyword: {Topic.Keyword}";
        }
    }
}
