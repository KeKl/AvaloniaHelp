using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaHelp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Controls
{
    /// <summary>
    ///     The search control.
    /// </summary>
    public class Search : UserControl
    {
        /// <summary>
        ///     Creates a new instance of <see cref="Search"/>.
        /// </summary>
        public Search()
        {
            this.InitializeComponent();
        }

        private string _searchString;
        private bool _includeTopicContent;
        private bool _onlyTraverseSelectedSectionOptionVisible;
        private bool _onlyTraverseSelectedSection;
        
        /// <summary>
        ///     The search string.
        /// </summary>
        public static readonly DirectProperty<Search, string> SearchStringProperty =
            AvaloniaProperty.RegisterDirect<Search, string>(
                nameof(SearchString), o => o.SearchString, (o, v) => o.SearchString = v, null, Avalonia.Data.BindingMode.TwoWay);

        /// <summary>
        ///     Search in topic content.
        /// </summary>
        public static readonly DirectProperty<Search, bool> IncludeTopicContentProperty =
            AvaloniaProperty.RegisterDirect<Search, bool>(
                nameof(IncludeTopicContent), o => o.IncludeTopicContent, (o, v) => o.IncludeTopicContent = v, default(bool), Avalonia.Data.BindingMode.TwoWay);

        /// <summary>
        ///     Search in topic content.
        /// </summary>
        public static readonly DirectProperty<Search, bool> OnlyTraverseSelectedSectionOptionVisibleProperty =
            AvaloniaProperty.RegisterDirect<Search, bool>(
                nameof(OnlyTraverseSelectedSectionOptionVisible), o => o.OnlyTraverseSelectedSectionOptionVisible, (o, v) => o.OnlyTraverseSelectedSectionOptionVisible = v);

        /// <summary>
        ///     Search in topic content.
        /// </summary>
        public static readonly DirectProperty<Search, bool> OnlyTraverseSelectedSectionProperty =
            AvaloniaProperty.RegisterDirect<Search, bool>(
                nameof(OnlyTraverseSelectedSection), o => o.OnlyTraverseSelectedSection, (o, v) => o.OnlyTraverseSelectedSection = v, default(bool), Avalonia.Data.BindingMode.TwoWay);

        /// <summary>
        ///     The search results.
        /// </summary>
        public static readonly DirectProperty<Search, ReactiveUI.ReactiveList<Section>> SearchResultsProperty =
            AvaloniaProperty.RegisterDirect<Search, ReactiveUI.ReactiveList<Section>>(
                nameof(SearchResults), o => o.SearchResults, (o, v) => o.SearchResults = v);

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public static readonly DirectProperty<Search, Section> SelectedResultProperty =
            AvaloniaProperty.RegisterDirect<Search, Section>(
                nameof(SelectedResult), o => o.SelectedResult, (o, v) => o.SelectedResult = v, null, Avalonia.Data.BindingMode.TwoWay);
        private Section _selectedResult;

        /// <summary>
        ///     The search string.
        /// </summary>
        public string SearchString
        {
            get { return _searchString; }
            set { SetAndRaise(SearchStringProperty, ref _searchString, value); }
        }

        /// <summary>
        ///     Includes the topic content.
        /// </summary>
        public bool IncludeTopicContent
        {
            get { return _includeTopicContent; }
            set { SetAndRaise(IncludeTopicContentProperty, ref _includeTopicContent, value); }
        }

        /// <summary>
        ///     Traverses down only the selected section.
        /// </summary>
        public bool OnlyTraverseSelectedSectionOptionVisible
        {
            get { return _onlyTraverseSelectedSectionOptionVisible; }
            set { SetAndRaise(OnlyTraverseSelectedSectionOptionVisibleProperty, ref _onlyTraverseSelectedSectionOptionVisible, value); }
        }

        /// <summary>
        ///     Traverses down only the selected section.
        /// </summary>
        public bool OnlyTraverseSelectedSection
        {
            get { return _onlyTraverseSelectedSection; }
            set { SetAndRaise(OnlyTraverseSelectedSectionProperty, ref _onlyTraverseSelectedSection, value); }
        }

        /// <summary>
        ///     The search results.
        /// </summary>
        public ReactiveUI.ReactiveList<Section> SearchResults { get; private set; }

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public Section SelectedResult
        {
            get { return _selectedResult; }
            set { SetAndRaise(SelectedResultProperty, ref _selectedResult, value); }
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
