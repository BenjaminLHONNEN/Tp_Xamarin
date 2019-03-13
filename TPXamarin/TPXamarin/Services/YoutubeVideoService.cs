using System;
using System.Net.Http;
using System.Threading.Tasks;
using TPXamarin.Models;

namespace TPXamarin.Services
{
    public static class YoutubeVideoService
    {
        public static async Task<YoutubeSearchResult> GetResearch(string search)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    var response = await http.GetAsync($"{ApiConstants.YoutubApiSearchUrl}?key={ApiConstants.ApiKey}&part=snippet&type=video&q={search}");
                    return YoutubeSearchResult.FromJson(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static async Task<YoutubeVideoDetail> GetVideoById(string id)
        {
            try
            {
                using (HttpClient http = new HttpClient())
                {
                    var response = await http.GetAsync($"{ApiConstants.YoutubApiVideoDetailUrl}?key={ApiConstants.ApiKey}&part=snippet,player,statistics&id={id}");
                    return YoutubeVideoDetail.FromJson(await response.Content.ReadAsStringAsync());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
