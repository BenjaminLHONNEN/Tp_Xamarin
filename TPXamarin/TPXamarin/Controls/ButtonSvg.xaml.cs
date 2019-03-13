using FFImageLoading.Forms;
using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPXamarin.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ButtonSvg : ContentView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonSvg), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ButtonSvg), null);

        public static readonly BindableProperty SvgSourceProperty =
            BindableProperty.Create("Source", typeof(string), typeof(ButtonSvg), default(string));

        public ButtonSvg ()
		{
			InitializeComponent ();
            
            InnerSvg.SetBinding(CachedImage.SourceProperty, new Binding("Source", source: this));
            
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += Clicked;

            gestureRecognizer.Command = new Command(() =>
            {
                if (Command != null && Command.CanExecute(CommandParameter))
                {
                    Command.Execute(CommandParameter);
                }
            });
            gestureRecognizer.CommandParameter = CommandParameter;

            InnerSvg.GestureRecognizers.Add(gestureRecognizer);
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

        public object Source
        {
            get => (string)GetValue(SvgSourceProperty);
            set => SetValue(SvgSourceProperty, value);
        }
        
        public event EventHandler Clicked;
    }
}