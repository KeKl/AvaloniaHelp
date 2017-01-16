using Avalonia;
using Avalonia.Controls;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp2
{
    public class Props
    {
        public static readonly AttachedProperty<string> TestProperty =
            AvaloniaProperty.RegisterAttached<Props, TextBox, string>("Test1");

        public static string GetTest(TextBox control)
        {
            return control.GetValue(TestProperty);
        }

        public static void SetTest(TextBox control, string value)
        {
            control.WhenAnyValue(x => x.Text).Subscribe(
                _ =>
                {
                    Debug.Write("sdssffs");
                });


            control.SetValue(TestProperty, value);
        }
    }
}
