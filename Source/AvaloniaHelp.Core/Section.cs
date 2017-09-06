using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Core
{
    /// <summary>
    ///     A section of a toc.
    /// </summary>
    public sealed class Section : HeaderedItem
    {
        /// <summary>
        ///     Creates a new instance of <see cref="Section"/>. 
        /// </summary>
        /// <param name="header">
        ///     The name of the <see cref="Section"/>.
        /// </param>
        /// <param name="subItems">
        ///     The child <see cref="Section"/>s.
        /// </param>
        public Section(string header, IEnumerable<Section> subItems)
            : this(header)
        {
            _subSections = new List<Section>(subItems);
        }

        /// <summary>
        ///     Creates a new instance of <see cref="Section"/>. 
        /// </summary>
        /// <param name="header">
        ///     The header of the <see cref="Section"/>.
        /// </param>
        public Section(string header)
            : base(header)
        {
        }
        
        private List<Section> _subSections = new List<Section>();
        
        /// <summary>
        ///     The parent <see cref="Section"/>.
        /// </summary>
        public Section Parent { get; private set; }

        /// <summary>
        ///     Child <see cref="Section"/>s.
        /// </summary>
        public IReadOnlyList<Section> SubSections { get { return _subSections; } }
        
        /// <summary>
        ///     Adds a <see cref="Section"/> as a child.
        /// </summary>
        /// <param name="subSection">
        ///     The <see cref="Section"/> to add.
        /// </param>
        public void AddSubSection(Section subSection)
        {
            Contract.Requires(subSection != null);
            Contract.Requires(!_subSections.Contains(subSection));

            subSection.Parent = this;
            _subSections.Add(subSection);
        }

        /// <summary>
        ///     Removes a <see cref="Section"/> as a child.
        /// </summary>
        /// <param name="subSection">
        ///     The <see cref="Section"/> to remove.
        /// </param>
        public void RemoveSubSection(Section subSection)
        {
            Contract.Requires(subSection != null);
            Contract.Requires(_subSections.Contains(subSection));

            subSection.Parent = null;
            _subSections.Remove(subSection);
        }


        


        public static Section Find(Section node, Func<Section, bool> findFunc)
        {
            throw new NotImplementedException();
        }



        
        /// <summary>
        ///     Searches the given section for the given header.
        /// </summary>
        /// <param name="node">
        ///     The start node.
        /// </param>
        /// <param name="header">
        ///     The header for which will be searched.
        /// </param>
        /// <returns>
        ///     The result.
        /// </returns>
        public static IEnumerable<Section> FindForHeader(Section node, string header)
        {
            Contract.Requires(node != null);

            var result = new List<Section>();

            if (node.Header.Contains(header, StringComparison.CurrentCultureIgnoreCase))
                result.Add(node);

            foreach (var child in node.SubSections)
            {
                var found = FindForHeader(child, header);
                if (found != null)
                    result.AddRange(found);
            }
            
            return result;
        }

        /// <summary>
        ///     Returns a string that represents the current <see cref="Section"/>.
        /// </summary>
        /// <returns>
        ///     A string that represents the current <see cref="Section"/>.
        /// </returns>
        public override string ToString()
        {
            return $"Header: {Header}, Topic Keyword: {Topic.Keyword}, Subsections Count: {SubSections.Count}";
        }
    }
}
