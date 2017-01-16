using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.ViewModels
{
    public abstract class BaseViewModel : ReactiveObject
    {
        public BaseViewModel()
        {
            TableOfContent = new ReactiveList<Section>(HelpManager.Instance.TableOfContent);
        }

        private Section _selectedSection;
        private string _searchString;
        private Topic _selectedSearchResult;

        /// <summary>
        ///     The topics in the ToC.
        /// </summary>
        public ReactiveList<Section> TableOfContent { get; private set; }

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
        ///     The search results.
        /// </summary>
        public ReactiveList<Topic> SearchResults { get; private set; }

        /// <summary>
        ///     The selected search result.
        /// </summary>
        public Topic SelectedSearchResult
        {
            get { return _selectedSearchResult; }
            set
            {
                this.RaiseAndSetIfChanged(ref _selectedSearchResult, value);
            }
        }

        public object Content
        {
            get
            {
                if(SelectedSection != null)
                    return HelpManager.Instance.GetContentForTopic(SelectedSection.Topic);

                return null;
            }
        }
    }
}
