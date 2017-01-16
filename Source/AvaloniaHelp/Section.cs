using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp
{
    /// <summary>
    ///     A section of a toc.
    /// </summary>
    public class Section
    {
        /// <summary>
        ///     Creates a new instance of <see cref="Section"/>. 
        /// </summary>
        /// <param name="header">
        ///     The header of the <see cref="Section"/>.
        /// </param>
        public Section(string header)
            : this(header, new Section[0])
        {

        }

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
        {
            Header = header;

            _subSections = new ObservableCollection<Section>(subItems);
            SubSections = new ReadOnlyCollection<Section>(_subSections);
        }

        private IList<Section> _subSections;

        /// <summary>
        ///     The header.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        ///     The parent <see cref="Section"/>.
        /// </summary>
        public Section Parent { get; private set; }

        /// <summary>
        ///     Child <see cref="Section"/>s.
        /// </summary>
        public IReadOnlyCollection<Section> SubSections { get; private set; }

        /// <summary>
        ///     The associated topic.
        /// </summary>
        public Topic Topic { get; set; }

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
    }
}
