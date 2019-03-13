using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TPXamarin.Controls
{
    public abstract class BaseButtonControl : ContentView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonImageText), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ButtonImageText), null);

        public BaseButtonControl()
        {
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += Clicked;

            gestureRecognizer.Command = Command;
            gestureRecognizer.CommandParameter = CommandParameter;

            GestureRecognizers.Add(gestureRecognizer);
        }

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public event EventHandler Clicked;
    }
}