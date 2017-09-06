using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaloniaHelp.ViewModels;

namespace AvaloniaHelp.Views
{
    public class QuickHelpView : UserControl
    {
        public QuickHelpView()
        {
            this.DataContext = new QuickHelpViewModel();
            this.InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}