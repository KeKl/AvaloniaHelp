﻿using Avalonia.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            AppBuilder.Configure<App>()
                   .UsePlatformDetect()
                   .Start<MainWindow>();
        }
    }
}
