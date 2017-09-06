using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaHelp.Behaviors
{
    public class DoubleTappedBehavior
    {
        /// <summary>
        ///     Gets or sets a string that describes the help keyword of a control. 
        /// </summary>
        public static readonly AttachedProperty<ICommand> CommandProperty = 
            AvaloniaProperty.RegisterAttached<DoubleTappedBehavior, Control, ICommand>("Command");

        /// <summary>
        ///     Gets the keyword string.
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static ICommand GetCommand(Control control)
        {
            System.Diagnostics.Contracts.Contract.Requires(control != null);

            return control.GetValue(CommandProperty);
        }

        /// <summary>
        ///     Sets the keyword string.
        /// </summary>
        /// <param name="control">
        ///     
        /// </param>
        /// <param name="value"></param>
        public static void SetCommand(Control control, ICommand value)
        {
            System.Diagnostics.Contracts.Contract.Requires(control != null);
            System.Diagnostics.Contracts.Contract.Requires(value != null);

            control.SetValue(CommandProperty, value);
        }
    }
}
