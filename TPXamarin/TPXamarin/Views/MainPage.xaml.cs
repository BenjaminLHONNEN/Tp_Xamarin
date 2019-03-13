using TPXamarin.Models;
using TPXamarin.ViewModels;
using Xamarin.Forms;

namespace TPXamarin
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BindingContext = new ListViewModel();
            MyList.ItemTapped += (object sender, ItemTappedEventArgs e) =>
            {
                YoutubeSearchItem video = (YoutubeSearchItem) e.Item;
                Navigation.PushAsync(new VideoDetail(video));
            };
        }
    }
}
