﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaHelp.Avalonia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.Views
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