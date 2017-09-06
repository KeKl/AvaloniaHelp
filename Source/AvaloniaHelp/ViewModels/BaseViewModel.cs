using AvaloniaHelp.Core;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.ViewModels
{
    /// <summary>
    ///     The base view model.
    /// </summary>
    public abstract class BaseViewModel : ReactiveObject
    {
        /// <summary>
        ///     Creates a new instance of <see cref="BaseViewModel"/>.
        /// </summary>
        public BaseViewModel()
        {
            Sections = new ReactiveList<Section>(HelpManager.Instance.Sections);
            Topics = new ReactiveList<Topic>(HelpManager.Instance.Topics);
            SearchResults = new ReactiveList<Section>();

            this.WhenAnyValue(p => p.SearchString)
                .Throttle(TimeSpan.FromMilliseconds(800), global::Avalonia.Threading.AvaloniaScheduler.Instance)
                .Subscribe(_ => LookingForResults());
        }

        private Section _selectedSection = null;
        private string _searchString = "";
        private bool _includeTopicContent = false;
        private bool _onlyTraverseSelectedSection = false;
        private Section _selectedSearchResult = null;

        /// <summary>
		/// 	Rebuilds the displayed options list.
		/// </summary>
		protected void LookingForResults()
        {
            var searchString = SearchString;
            var result = new ReactiveList<Section>();
            ReactiveList<Section> root;

            var includeTopicContent = IncludeTopicContent;
            var onlyTraverseSelectedSection = OnlyTraverseSelectedSection;

            if (onlyTraverseSelectedSection && SelectedSection != null)
            {
                root = new ReactiveList<Section>();
                root.Add(SelectedSection);
            }
            else
            {
                root = Sections;
            }
            
            foreach (var section in root)
                result.AddRange(Section.FindForHeader(section, searchString));

            var topicsContainingSearchString = new List<Topic>();
            if (includeTopicContent)
            {
                foreach(var topic in Topics)
                {
                    if (topic.SearchForString(searchString))
                        topicsContainingSearchString.Add(topic);
                }
            }





            SearchResults.Clear();
            SearchResults.AddRange(result);
        }



        /// <summary>
        ///     The table of content.
        /// </summary>
        public ReactiveList<Section> Sections { get; private set; }
        
        /// <summary>
        ///     The selected section in ToC.
        /// </summary>
        public Section SelectedSection
        {
            get { return _selectedSection; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSection, value);
                this.RaisePropertyChanged("Content");
            }
        }

        /// <summary>
        ///     The topics.
        /// </summary>
        public ReactiveList<Topic> Topics { get; private set; }

        /// <summary>
        ///     The search string.
        /// </summary>
        public string SearchString
        {
            get { return _searchString; }
            set
            {
                this.RaiseAndSetIfChanged(ref _searchString, value);
            }
        }

        /// <summary>
        ///     Search in topic content.
        /// </summary>
        public bool IncludeTopicContent
        {
            get { return _includeTopicContent; }
            set
            {
                this.RaiseAndSetIfChanged(ref _includeTopicContent, value);
            }
        }

        /// <summary>
        ///     Traverses down only the selected section.
        /// </summary>
        public bool OnlyTraverseSelectedSection
        {
            get { return _onlyTraverseSelectedSection; }
            set
            {
                this.RaiseAndSetIfChanged(ref _onlyTraverseSelectedSection, value);
            }
        }

        /// <summary>
        ///     The search results.
        /// </summary>
        public ReactiveList<Section> SearchResults { get; private set; }

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public Section SelectedSearchResult
        {
            get { return _selectedSearchResult; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSearchResult, value);
                this.RaisePropertyChanged("Content");
            }
        }

        public object Content
        {
            get
            {
                if (SelectedSection != null)
                    //return HelpManager.Instance.GetContentViewForTopic(SelectedSection.Topic);
                    return HelpManager.Instance.GetContentForTopic(SelectedSection.Topic);

                return null;
            }
        }

        
    }
}
