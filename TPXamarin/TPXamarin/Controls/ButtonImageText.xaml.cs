using System;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPXamarin.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ButtonImageText : ContentView
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonImageText), null);

        public static readonly BindableProperty CommandParameterProperty =
            BindableProperty.Create("CommandParameter", typeof(object), typeof(ButtonImageText), null);

        public static readonly BindableProperty ButtonTextProperty =
            BindableProperty.Create("ButtonText", typeof(string), typeof(ButtonImageText), default(string));

        public static readonly BindableProperty ImageSourceProperty =
            BindableProperty.Create("Source", typeof(ImageSource), typeof(ButtonImageText), default(ImageSource));

        public ButtonImageText()
        {
            InitializeComponent();

            InnerLabel.SetBinding(Label.TextProperty, new Binding("ButtonText", source: this));
            InnerImage.SetBinding(Image.SourceProperty, new Binding("Source", source: this));

            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += Clicked;

            gestureRecognizer.Command = Command;
            gestureRecognizer.CommandParameter = CommandParameter;

            GestureRecognizers.Add(gestureRecognizer);
        }

        public string ButtonText
        {
            get => (string) GetValue(ButtonTextProperty);
            set => SetValue(ButtonTextProperty, value);
        }


        public ICommand Command
        {
            get => (ICommand) GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        public object CommandParameter
        {
            get => GetValue(CommandParameterProperty);
            set => SetValue(CommandParameterProperty, value);
        }

        public object Source
        {
            get => (ImageSource) GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public event EventHandler Clicked;
    }
}