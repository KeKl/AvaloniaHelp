using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Controls;

namespace AvaloniaHelp
{
    public abstract class ContentView<TContent> : IContentView
    {
        public ContentView()
        {

        }

        protected Control View { get; set; }

        public Control GetView() => View;

        public abstract void SetContent(TContent content);
    }
}
