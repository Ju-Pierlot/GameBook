using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace GameBook.Views
{
    public class DialogToCommandPipe
    {
        public static DependencyProperty CommandProperty = DependencyProperty.RegisterAttached(
            "Command",
            typeof(ICommand),
            typeof(DialogToCommandPipe),
            new FrameworkPropertyMetadata(null, new PropertyChangedCallback(DialogToCommandPipe.CommandChanged)));

        public static void SetCommand(DependencyObject target, ICommand value)
        {
            Console.Write("SetCommand");
            target.SetValue(DialogToCommandPipe.CommandProperty, value);
        }

        public static ICommand GetCommand(DependencyObject target)
        {
            Console.Write("GetCommand");
            return (ICommand)target.GetValue(DialogToCommandPipe.CommandProperty);
        }

        private static void CommandChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            var window = target as Window;
            if (window != null)
            {
                window.Closed += (o, evt) => GetCommand(target)?.Execute(null);
            }
        }
    }
}
