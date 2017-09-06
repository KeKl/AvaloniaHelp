using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Core
{
    /// <summary>
    ///     A help topic.
    /// </summary>
    public sealed class Topic
    {
        /// <summary>
        ///     Creates a new instance of <see cref="Topic"/>. 
        /// </summary>
        /// <param name="keyword">
        ///     The keyword of the topic.
        /// </param>
        /// <param name="reference">
        ///     The reference of the topic.
        /// </param>
        public Topic(string keyword, IReference reference)
            : this(keyword)
        {
            Reference = reference;
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Topic"/>.
        /// </summary>
        /// <param name="keyword">
        ///     The keyword of the topic.
        /// </param>
        public Topic(string keyword)
        {
            Keyword = keyword;
        }
        
        /// <summary>
        ///     The keyword of the topic.
        /// </summary>
        public string Keyword { get; private set; }

        /// <summary>
        ///     The reference.
        /// </summary>
        public IReference Reference { get; set; }


        public bool SearchForString(string content)
        {
            return Reference.ContainsString(content);
        }
    }
}