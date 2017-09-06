using Avalonia.Controls.Html;
using AvaloniaHelp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaTestApp
{
    public class HtmlLabelContentView : ContentView<string>
    {
        public HtmlLabelContentView()
        {
            View = _label;
        }

        private HtmlLabel _label = new HtmlLabel();

        public override void SetContent(string content)
        {
            _label.Text = content;
        }
    }
}
