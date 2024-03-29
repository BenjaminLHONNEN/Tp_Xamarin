﻿using System.Threading.Tasks;
using TPXamarin.Models;
using TPXamarin.Resx;
using TPXamarin.Services;
using Xamarin.Forms;

namespace TPXamarin.ViewModels
{
    public class ListViewModel : BaseViewModel
    {
        private YoutubeSearchResult _videoList;
        
        public YoutubeSearchResult VideoList
        {
            get { return _videoList; }
            set
            {
                _videoList = value;
                OnPropertyChanged();
            }
        }

        private string _research;

        public string Research
        {
            get { return _research; }
            set {
                if (_research != value)
                {
                    _research = value;
                    OnPropertyChanged();
                }
            }
        }


        public ListViewModel()
        {
            Title = LocalizedResources.VideoList;
            GetYoutubeVideos = new Command(async () => { await getYoutubeVideos(); });
            ResearchYoutubeVideos = new Command(async () => { await getYoutubeVideos(); });
            GetYoutubeVideos.Execute(null);
        }

        private YoutubeSearchItem _seletedVideo;

        public YoutubeSearchItem SelectedVideo
        {
            get { return _seletedVideo; }
            set
            {
                _seletedVideo = value;
                OnPropertyChanged();
            }
        }

        public Command GetYoutubeVideos { get; set; }
        public Command ResearchYoutubeVideos { get; set; }

        private async Task getYoutubeVideos()
        {
            VideoList = await YoutubeVideoService.GetResearch(_research);
        }
    }
}
