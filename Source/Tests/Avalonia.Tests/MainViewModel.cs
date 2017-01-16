using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Tests
{
    public class MainViewModel : ReactiveObject
    {
        public MainViewModel()
        {
            Topics = new ObservableCollection<Topic>();
            //SelectedTopic = new Topic();
            ClickCommand = ReactiveCommand.Create();
            ClickCommand.Subscribe(x =>
            {
                var s = SelectedTopic;
            });

            AddFake();
        }

        public ObservableCollection<Topic> Topics { get; private set; }

        Topic _selectedTopic;
        public Topic SelectedTopic
        {
            get { return _selectedTopic; }
            set { this.RaiseAndSetIfChanged(ref _selectedTopic, value); }
        }

        public ReactiveCommand<object> ClickCommand { get; private set; }

        private void AddFake()
        {
            var mainTopic1 = new Topic();
            mainTopic1.Header = "Main 1";
            mainTopic1.Content = "TestText";

            var mainTopic2 = new Topic();
            mainTopic2.Header = "Main 2";
            mainTopic2.Content = "TestText 2";
            
            Topics.Add(mainTopic1);
            Topics.Add(mainTopic2);
        }
    }
}