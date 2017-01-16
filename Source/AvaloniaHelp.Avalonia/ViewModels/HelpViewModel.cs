using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.ViewModels
{
    public class HelpViewModel : BaseViewModel
    {
        public HelpViewModel()
        {
            OpenedTopics = new ReactiveList<Topic>();
        }
        
        private Topic _activeTopic;
        
        /// <summary>
        ///     Alle topics in the tabs.
        /// </summary>
        public ReactiveList<Topic> OpenedTopics { get; private set; }

        /// <summary>
        ///     The active topic-tab.
        /// </summary>
        public Topic ActiveTopic
        {
            get { return _activeTopic; }
            set { this.RaiseAndSetIfChanged(ref _activeTopic, value); }
        }

        public object TopicContent
        {
            get
            {
                if (SelectedSection != null)
                    return HelpManager.Instance.GetContentForTopic(SelectedSection.Topic);

                return null;
            }
        }
    }
}
