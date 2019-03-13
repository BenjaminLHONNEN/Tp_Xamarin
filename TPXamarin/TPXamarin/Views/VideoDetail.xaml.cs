using TPXamarin.Models;
using TPXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TPXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class VideoDetail : ContentPage
	{
		public VideoDetail (YoutubeSearchItem video)
		{
			InitializeComponent ();

            /*HtmlWebViewSource personHtmlSource = new HtmlWebViewSource();
            personHtmlSource.SetBinding(HtmlWebViewSource.HtmlProperty, "HTMLDesc");
            personHtmlSource.Html = @"<iframe width='100%' height='100%' src='https://www.youtube.com/embed/BEoGsr0WXVw' frameborder='0' allow='accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture' allowfullscreen></iframe>";
            var browser = new WebView();
            browser.Source = personHtmlSource;
            Content = browser;*/

            BindingContext = new DetailViewModel(video);
        }
	}
}