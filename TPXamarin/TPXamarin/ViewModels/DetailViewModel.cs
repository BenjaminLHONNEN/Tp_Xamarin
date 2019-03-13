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
        
        private bool _isStatisticsTabVisible = false;
        private bool _isYoutubeTabVisible = true;
        

        public bool IsStatisticsTabVisible
        {
            get { return _isStatisticsTabVisible; }
            set
            {
                _isStatisticsTabVisible = value;
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
        public Command SetCurrentTabToStatistics { get; set; }

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
            Task.Run(async () => { await getVideo(video.YoutubeSearchId.VideoId); });
            
            SetCurrentTabToYoutube = new Command(() =>
            {
                IsStatisticsTabVisible = false;
                IsYoutubeTabVisible = true;
            });
            SetCurrentTabToStatistics = new Command(() =>
            {
                IsStatisticsTabVisible = true;
                IsYoutubeTabVisible = false;
            });
        }
    }
}
