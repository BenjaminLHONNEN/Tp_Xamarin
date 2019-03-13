using System.Linq;
using System.Threading.Tasks;
using TPXamarin.Models;
using TPXamarin.Services;
using Xamarin.Forms;

namespace TPXamarin.ViewModels
{
    public class DetailViewModel : BaseViewModel
    {
        private YoutubeVideoDetailItem _video;

        private bool _isMp3TabVisible = false;
        private bool _isImageTabVisible = true;
        private bool _isYoutubeTabVisible = false;

        public bool IsMp3TabVisible
        {
            get { return _isMp3TabVisible; }
            set
            {
                _isMp3TabVisible = value;
                OnPropertyChanged();
            }
        }

        public bool IsImageTabVisible
        {
            get { return _isImageTabVisible; }
            set
            {
                _isImageTabVisible = value;
                OnPropertyChanged();
            }
        }
        public bool IsYoutubeTabVisible
        {
            get { return _isYoutubeTabVisible; }
            set
            {
                _isYoutubeTabVisible = value;
                OnPropertyChanged();
            }
        }
        public Command SetCurrentTabToYoutube { get; set; }
        public Command SetCurrentTabToImage { get; set; }
        public Command SetCurrentTabToMp3 { get; set; }

        public YoutubeVideoDetailItem Video
        {
            get { return _video; }
            set
            {
                _video = value; 
                OnPropertyChanged();
            }
        }

        private async Task getVideo(string id)
        {
            var video = await YoutubeVideoService.GetVideoById(id);
            Video = video.YoutubeVideoDetailItems.FirstOrDefault();
            Title = Video.YoutubeVideoDetailSnippet.Title;
        }


        public DetailViewModel(YoutubeSearchItem video)
        {
            Task.Run(() => { getVideo(video.YoutubeSearchId.VideoId); });
            
            SetCurrentTabToYoutube = new Command(() =>
            {
                IsMp3TabVisible = false;
                IsImageTabVisible = false;
                IsYoutubeTabVisible = true;
            });
            SetCurrentTabToImage = new Command(() =>
            {
                IsMp3TabVisible = false;
                IsImageTabVisible = true;
                IsYoutubeTabVisible = false;
            });
            SetCurrentTabToMp3 = new Command(() =>
            {
                IsMp3TabVisible = true;
                IsImageTabVisible = false;
                IsYoutubeTabVisible = false;
            });
        }
    }
}
