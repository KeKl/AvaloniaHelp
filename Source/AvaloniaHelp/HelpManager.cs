using System;
using System.Reflection;
using Avalonia;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;
using ReactiveUI;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using AvaloniaHelp.Provider;
using AvaloniaHelp.Core;

namespace AvaloniaHelp
{
    /// <summary>
    ///     The help manager.
    /// </summary>
    public sealed class HelpManager
    {
        /// <summary>
        ///     Creates a new instance of <see cref="HelpManager"/>.
        /// </summary>
        /// <param name="contentProvider">
        ///     The content provider.
        /// </param>
        public HelpManager(IContentProvider contentProvider)
        {
            System.Diagnostics.Contracts.Contract.Requires(contentProvider != null);

            _contentProvider = contentProvider;

            Topics = new ReactiveList<Topic>();
            Sections = new ReactiveList<Section>();
            
            if(AutomaticToCGeneration)
                Topics.Changed.Subscribe(args => Sections = _defaultToCFactory(Instance));
        }
        
        /// <summary>
        ///     Holds a SyncRoot to be thread safe.
        /// </summary>
        private static readonly object SyncRoot = new object();

        /// <summary>
        ///     Holds the instance of singleton.
        /// </summary>
        private static HelpManager _instance;
        
        /// <summary>
        ///     Holds the content provider.
        /// </summary>
        private IContentProvider _contentProvider;
        
        /// <summary> 
        ///     The default table of content factory 
        ///     which provides the help manager as a parameter. 
        /// </summary> 
        private static Func<HelpManager, ReactiveList<Section>> _defaultToCFactory = helpManager => CreateDefaultToc(helpManager);
        
        /// <summary>
        ///     Gets or sets a string that describes the help keyword of a control. 
        /// </summary>
        public static readonly AttachedProperty<string> KeywordProperty = 
            AvaloniaProperty.RegisterAttached<HelpManager, Control, string>("Keyword1");
        
        /// <summary>
        ///     Gets the <see cref="HelpManager"/> singleton. 
        ///     If the underlying instance is null, a instance will be created. 
        /// </summary> 
        public static HelpManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock(SyncRoot)
                    {
                        if (_instance == null)
                            _instance = new HelpManager(null);
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        ///     Holds the content provider.
        /// </summary>
        public IContentProvider ContentProvider {  get { return _contentProvider; } }
        
        /// <summary>
        ///     Holds the available topics.
        /// </summary>
        public ReactiveList<Topic> Topics { get; private set; }

        /// <summary>
        ///     Holds the table of content.
        /// </summary>
        public ReactiveList<Section> Sections { get; private set; }

        /// <summary>
        ///     Specifies whether the ToC should be 
        ///     generated automatically.
        /// </summary>
        public static bool AutomaticToCGeneration { get; set; }
        
        /// <summary>
        ///     Gets the keyword string.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static string GetKeyword(Control control)
        {
            System.Diagnostics.Contracts.Contract.Requires(control != null);

            return control.GetValue(KeywordProperty);
        }

        /// <summary>
        ///     Sets the keyword string.
        /// </summary>
        /// <param name="control">
        ///     
        /// </param>
        /// <param name="value"></param>
        public static void SetKeyword(Control control, string value)
        {
            System.Diagnostics.Contracts.Contract.Requires(control != null);
            System.Diagnostics.Contracts.Contract.Requires(!string.IsNullOrWhiteSpace(value));
            
            control.SetValue(KeywordProperty, value);
        }
        
        ///// <summary>
        /////     Gets the topic for the given keyword.
        ///// </summary>
        ///// <param name="keyword">
        /////     The keyword.
        ///// </param>
        ///// <returns>
        /////     The found topic.
        ///// </returns>
        //public Topic GetTopicForKeyword(string keyword)
        //{
        //    System.Diagnostics.Contracts.Contract.Requires(!string.IsNullOrWhiteSpace(keyword));

        //    Topic result = null;
        //    foreach (var t in Instance.Topics)
        //        result = GetTopic(t, keyword);

        //    return result;
        //}

        /// <summary>
        ///     Recursive search for the keyword in the 
        ///     subsection property.
        /// </summary>
        /// <param name="section">
        ///     The parent section.
        /// </param>
        /// <param name="keyword">
        ///     The keyword.
        /// </param>
        /// <returns>
        ///     The child section with the given keyword.
        /// </returns>
        private static Section GetSection(Section section, string header)
        {
            if (string.IsNullOrWhiteSpace(header))
                return null;

            if (section.Header == header)
                return section;

            return null;
        }
        
        private static void ShowHelpForTopic(string keyword)
        {
            //Topic topic = null;
            foreach (var t in Instance.Topics)
            {
                if (t.Keyword == keyword)
                {
                    Instance.OnActiveTopicChanged(t);
                    //topic = t;
                }
            }

            //Instance.OnActiveTopicChanged(topic);
        }

        /// <summary>
        ///     Sets the content provider.
        /// </summary>
        /// <param name="provider">
        ///     The content provider to set.
        /// </param>
        public static void SetContentProvider(IContentProvider provider)
        {
            System.Diagnostics.Contracts.Contract.Requires(provider != null);

            Instance._contentProvider = provider;
        }

        internal object GetContentViewForTopic(Topic topic)
        {
            System.Diagnostics.Contracts.Contract.Requires(topic != null);

            return null;

            //return Instance._contentProvider.
        }

        /// <summary>
        ///     Gets the content for the given topic.
        /// </summary>
        /// <param name="topic">
        ///     The topic.
        /// </param>
        /// <returns>
        ///     The content of the givent topic.
        /// </returns>
        public object GetContentForTopic(Topic topic)
        {
            System.Diagnostics.Contracts.Contract.Requires(topic != null);

            return Instance._contentProvider.GetContent(topic);
        }

        /// <summary>
        ///     Sets the default table of content factory.
        /// </summary>
        /// <param name="ToCFactory">
        ///     The table of content factory which provides the helpmanager as a parameter.
        /// </param>
        public static void SetDefaultToCFactory(Func<HelpManager, ReactiveList<Section>> toCFactory)
        {
            _defaultToCFactory = toCFactory;
        }

        private static ReactiveList<Section> CreateDefaultToc(HelpManager manager)
        {
            if (manager.Topics.Count == 0)
                return null;

            var resultToC = new ReactiveList<Section>();

            foreach(var topic in manager.Topics)
            {






                var strings = topic.Keyword.Split('|');
                if (strings.Count() == 0)
                    throw new Exception();
                
                var section = CreateSection(strings.Last(), topic);

                if (strings.Count() == 1)
                    manager.Sections.Add(section);
                else
                {
                    var parent = GetParent(strings[strings.Count()-2]);
                    parent.AddSubSection(section);
                }
            }

            return null;
        }
                
        private static Section CreateSection(string header, Topic topic)
        {
            var section = new Section(header);
            section.Topic = topic;

            return section;
        }

        private static Section GetParent(string header)
        {

            return null;
        }
















        /// <summary>
        ///     
        /// </summary>
        private Subject<Topic> _activeTopicChanged = new Subject<Topic>();

        /// <summary>
        ///     Occurs when the the active topic has changed.
        /// </summary>
        public IObservable<Topic> ActiveTopicChanged
        {
            get { return this._activeTopicChanged.AsObservable(); }
        }
        
        /// <summary>
        ///     Raises the active topic changed event.
        /// </summary>
        /// <param name="topic">
        ///     The new active topic.
        /// </param>
        public void OnActiveTopicChanged(Topic topic)
        {
            System.Diagnostics.Contracts.Contract.Requires(topic != null);

            this._activeTopicChanged.OnNext(topic);
        }









        public static readonly AttachedProperty<string> UpdateTriggerProperty
            = AvaloniaProperty.RegisterAttached<HelpManager, Control, string>("UpdateTrigger1");
        
        public static string GetUpdateTrigger(Control control)
        {
            return control.GetValue(UpdateTriggerProperty);
        }

        public static void SetUpdateTrigger(Control control, string value)
        {
            var obs = Observable.FromEventPattern<EventHandler<AvaloniaPropertyChangedEventArgs>, AvaloniaPropertyChangedEventArgs>(
                                        h => control.PropertyChanged += h,
                                        h => control.PropertyChanged -= h).Where(e => e.EventArgs.Property.Name == value);

            var obs2 = Observable.Create<object>(o =>
            {
                return Observable.FromEventPattern<EventHandler<AvaloniaPropertyChangedEventArgs>, AvaloniaPropertyChangedEventArgs>(
                    h => control.PropertyChanged += h,
                    h => control.PropertyChanged -= h).Subscribe(o);
            });

            obs.Subscribe(s =>
            {
                if ((bool)s.EventArgs.NewValue == true)
                    ShowHelpForTopic(GetKeyword(control));

                if ((bool)s.EventArgs.NewValue == false)
                    ShowHelpForTopic("root");
            });

            control.SetValue(UpdateTriggerProperty, value);
        }        
    }
}
