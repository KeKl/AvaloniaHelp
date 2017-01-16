using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using ReactiveUI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.Controls
{
    /// <summary>
    ///     The table of content control.
    /// </summary>
    public class ToC : UserControl
    {
        /// <summary>
        ///     Creates a new instance of <see cref="ToC"/>.
        /// </summary>
        public ToC()
        {
            _sections = new ReactiveList<Section>();
            this.InitializeComponent();
        }

        ReactiveList<Section> _sections;
        private Section _selectedSection;

        /// <summary>
        ///     The topics property.
        /// </summary>
        public static readonly DirectProperty<ToC, ReactiveList<Section>> SectionsProperty =
            AvaloniaProperty.RegisterDirect<ToC, ReactiveList<Section>>(
                nameof(Sections), o => o.Sections, (o, v) => o.Sections = v);

        /// <summary>
        ///     The selected topic property.
        /// </summary>
        public static readonly DirectProperty<ToC, Section> SelectedSectionProperty =
            AvaloniaProperty.RegisterDirect<ToC, Section>(
                nameof(SelectedSection), o => o.SelectedSection, (o, v) => o.SelectedSection = v);
        
        /// <summary>
        ///     The sections property.
        /// </summary>
        public ReactiveList<Section> Sections
        {
            get
            {
                return _sections;
            }
            set
            {
                _sections = value;
            }
        }

        /// <summary>
        ///     The selected section property.
        /// </summary>
        public Section SelectedSection
        {
            get { return _selectedSection; }
            set { SetAndRaise(SelectedSectionProperty, ref _selectedSection, value); }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
