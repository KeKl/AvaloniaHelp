using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia;

namespace TestApp2
{
	public class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}