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
    public class QuickHelpViewModel : ReactiveObject
    {
        public QuickHelpViewModel()
        {
            HelpManager.Instance.ActiveTopicChanged.Subscribe(
                t => 
                {
                    if(t != null)
                        ActiveTopic = t;
                });

            //this.WhenAnyValue(x => x.ActiveTopic).Subscribe(
            //    t =>
            //    {
            //        if (t != null)
            //            Title = t.Keyword;
            //    }
            //);
        }

        private Topic _activeTopic;
        private string _title;

        /// <summary>
        ///     The active topic.
        /// </summary>
        public Topic ActiveTopic
        {
            get { return _activeTopic; }
            set
            {
                this.RaiseAndSetIfChanged(ref _activeTopic, value);
                this.RaisePropertyChanged(nameof(Title));
                this.RaisePropertyChanged(nameof(ActiveContent));
            }
        }


        public string Title
        {
            get { return "Topic: " + ActiveTopic?.Keyword; }
            //set { this.RaiseAndSetIfChanged(ref _title, value); }
        }

        /// <summary>
        ///     The active content.
        /// </summary>
        public object ActiveContent
        {
            get
            {
                if (ActiveTopic != null)
                    return HelpManager.Instance.GetContentForTopic(ActiveTopic);

                return null;
            }
        }
    }
}
