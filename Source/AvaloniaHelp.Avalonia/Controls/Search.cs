using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.Controls
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
            SearchResults = new ReactiveUI.ReactiveList<Topic>();
            this.InitializeComponent();
        }

        private string _searchString;

        /// <summary>
        ///     The search string.
        /// </summary>
        public static readonly DirectProperty<Search, string> SearchStringProperty =
            AvaloniaProperty.RegisterDirect<Search, string>(
                nameof(SearchString), o => o.SearchString, (o, v) => o.SearchString = v);

        /// <summary>
        ///     The search results.
        /// </summary>
        public static readonly DirectProperty<Search, ReactiveUI.ReactiveList<Topic>> SearchResultsProperty =
            AvaloniaProperty.RegisterDirect<Search, ReactiveUI.ReactiveList<Topic>>(
                nameof(SearchResults), o => o.SearchResults, (o, v) => o.SearchResults = v);

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public static readonly DirectProperty<Search, Topic> SelectedResultProperty =
            AvaloniaProperty.RegisterDirect<Search, Topic>(
                nameof(SelectedResult), o => o.SelectedResult, (o, v) => o.SelectedResult = v);

        /// <summary>
        ///     The search string.
        /// </summary>
        public string SearchString
        {
            get { return _searchString; }
            set { SetAndRaise(SearchStringProperty, ref _searchString, value); }
        }

        /// <summary>
        ///     The search results.
        /// </summary>
        public ReactiveUI.ReactiveList<Topic> SearchResults { get; private set; }

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public Topic SelectedResult { get; private set; }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
