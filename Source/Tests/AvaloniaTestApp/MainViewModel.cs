using AvaloniaHelp;
using AvaloniaHelp.Core;
using AvaloniaHelp.Provider;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTestApp
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            provider = new StringContentProvider();
            provider.ContentViewFactory = CreateContentControl;
            HelpManager.SetContentProvider(provider);
            
            //HelpManager.AutomaticToCGeneration = false;
            //HelpManager.SetDefaultToCFactory(GenerateToc);

            AddTopics();
            CreateToC();

            //var md = System.IO.File.ReadAllText(@"C:\Users\lweklk1\Downloads\Avalonia\Chapter-2\2_2_Layout.md");
            //var html = Markdig.Markdown.ToHtml(md);

            //HtmlText = html;
        }

        private IContentView CreateContentControl()
        {
            return new HtmlLabelContentView();
        }

        private StringContentProvider provider;

        //public string HtmlText { get; set; }

        private void AddTopics()
        {
            var root = new Topic("root");
            provider.SetContent(root, "This is the root of the help.");

            var mainTopic1 = new Topic("root|main1");
            provider.SetContent(mainTopic1, "Main 1 help.");

            var subTopic1 = new Topic("root|main1|sub1");
            provider.SetContent(subTopic1, "This is the sub1 help.");

            var mainTopic2 = new Topic("root|main2");
            provider.SetContent(mainTopic2, "Main 2 help.");

            var subTopic2 = new Topic("root|main2|sub2");
            provider.SetContent(subTopic2, "This is the sub2 help.");
            
            HelpManager.Instance.Topics.Add(root);
            HelpManager.Instance.Topics.Add(mainTopic1);
            HelpManager.Instance.Topics.Add(subTopic1);
            HelpManager.Instance.Topics.Add(mainTopic2);
            HelpManager.Instance.Topics.Add(subTopic2);
        }

        private void CreateToC()
        {
            var root = new Section("Test App Help");
            root.Topic = HelpManager.Instance.Topics.FirstOrDefault(t => t.Keyword == "root");

            var mainSec1 = new Section("Main 1");
            mainSec1.Topic = HelpManager.Instance.Topics.FirstOrDefault(t => t.Keyword == "root|main1");

            var subSec1 = new Section("Sub 1");
            subSec1.Topic = HelpManager.Instance.Topics.FirstOrDefault(t => t.Keyword == "root|main1|sub1");
            mainSec1.AddSubSection(subSec1);

            var mainSec2 = new Section("Main 2");
            mainSec2.Topic = HelpManager.Instance.Topics.FirstOrDefault(t => t.Keyword == "root|main2");

            var subSec2 = new Section("Sub 2");
            subSec2.Topic = HelpManager.Instance.Topics.FirstOrDefault(t => t.Keyword == "root|main2|sub2");
            mainSec2.AddSubSection(subSec2);

            root.AddSubSection(mainSec1);
            root.AddSubSection(mainSec2);

            HelpManager.Instance.Sections.Add(root);
        }

        private ReactiveList<Section> GenerateToc(HelpManager helpManager)
        {
            var toc = new ReactiveList<Section>();

            var root = new Section("Test App Help");
            root.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root");

            var mainSec1 = new Section("Main 2");
            mainSec1.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main1");

            var subSec1 = new Section("Sub 1");
            subSec1.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main1|sub1");
            mainSec1.AddSubSection(subSec1);

            var mainSec2 = new Section("Main 2");
            mainSec2.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main2");

            var subSec2 = new Section("Sub 2");
            subSec2.Topic = helpManager.Topics.FirstOrDefault(t => t.Keyword == "root|main2|sub2");
            mainSec2.AddSubSection(subSec2);

            root.AddSubSection(mainSec1);
            root.AddSubSection(mainSec2);

            toc.Add(root);

            return toc;
        }
    }
}