using System;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia;

namespace AvaloniaTestApp
{
	public class App : Application
	{
		public override void Initialize()
		{
			AvaloniaXamlLoader.Load(this);
		}
	}
}