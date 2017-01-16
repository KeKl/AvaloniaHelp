using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Tests
{
    public class Topic
    {
        public Topic()
            : this("", null, new Topic[0])
        {

        }

        public Topic(string name)
            : this(name, null, new Topic[0])
        {

        }


        public Topic(string name, object content, IEnumerable<Topic> subTopics)
        {
            Header = name;
            Content = content;
            _subTopics = new ObservableCollection<Topic>(subTopics);
            SubTopics = new ReadOnlyCollection<Topic>(_subTopics);
        }

        private IList<Topic> _subTopics;
        
        public string Header { get; set; }

        public object Content { get; set; }

        public Topic Parent { get; private set; }

        public IReadOnlyCollection<Topic> SubTopics { get; private set; }
        
        public void AddSubTopic(Topic subTopic)
        {
            subTopic.Parent = this;
            _subTopics.Add(subTopic);
        }

        public void RemoveSubTopic(Topic subTopic)
        {
            subTopic.Parent = null;
            _subTopics.Remove(subTopic);
        }
    }
}