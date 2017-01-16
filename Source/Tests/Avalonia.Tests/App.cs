using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia;

namespace Avalonia.Tests
{
	public class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}