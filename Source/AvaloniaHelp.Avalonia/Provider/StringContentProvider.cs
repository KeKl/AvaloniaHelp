using Avalonia;
using Avalonia.Controls;
using AvaloniaHelp.Avalonia;
using AvaloniaHelp.Avalonia.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaHelp.Avalonia.Provider
{
    /// <summary>
    ///     A simple implementation of a content provider.
    /// </summary>
    public class StringContentProvider : ContentProvider<string>
    {


        ///// <summary>
        /////     The help text.
        ///// </summary>
        //public static readonly AttachedProperty<string> HelpTextProperty
        //    = AvaloniaProperty.RegisterAttached<HelpManager, Control, string>("HelpText");
        
        ///// <summary>
        /////     Gets the help text.
        ///// </summary>
        ///// <param name="control">
        /////     The control.
        ///// </param>
        ///// <returns>
        /////     The help text.
        ///// </returns>
        //public static string GetHelpText(Control control)
        //{
        //    return control.GetValue(HelpTextProperty);
        //}

        ///// <summary>
        /////     Sets the help text.
        ///// </summary>
        ///// <param name="control">
        /////     The control.
        ///// </param>
        ///// <param name="value">
        /////     The help text.
        ///// </param>
        //public static void SetHelpText(Control control, string value)
        //{
        //    control.SetValue(HelpTextProperty, value);
        //}
    }
}