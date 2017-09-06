using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaHelp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Views
{
    public class HelpView : UserControl
    {
        public HelpView()
        {
            this.DataContext = new HelpViewModel();
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}
