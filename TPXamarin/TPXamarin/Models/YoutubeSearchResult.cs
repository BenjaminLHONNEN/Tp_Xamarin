using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace TPXamarin.Models
{
    public partial class YoutubeSearchResult
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }

        [JsonProperty("regionCode")]
        public string RegionCode { get; set; }

        [JsonProperty("pageInfo")]
        public YoutubeSearchPageInfo YoutubeSearchPageInfo { get; set; }

        [JsonProperty("items")]
        public YoutubeSearchItem[] YoutubeSearchItems { get; set; }
    }

    public class YoutubeSearchItem
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public YoutubeSearchId YoutubeSearchId { get; set; }

        [JsonProperty("snippet")]
        public YoutubeSearchSnippet YoutubeSearchSnippet { get; set; }
    }

    public class YoutubeSearchId
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("videoId")]
        public string VideoId { get; set; }
    }

    public class YoutubeSearchSnippet
    {
        [JsonProperty("publishedAt")]
        public DateTimeOffset PublishedAt { get; set; }

        [JsonProperty("channelId")]
        public string ChannelId { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("thumbnails")]
        public YoutubeSearchThumbnails YoutubeSearchThumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }
    }

    public class YoutubeSearchThumbnails
    {
        [JsonProperty("default")]
        public YoutubeSearchDefault YoutubeSearchDefault { get; set; }

        [JsonProperty("medium")]
        public YoutubeSearchDefault Medium { get; set; }

        [JsonProperty("high")]
        public YoutubeSearchDefault High { get; set; }
    }

    public class YoutubeSearchDefault
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public class YoutubeSearchPageInfo
    {
        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("resultsPerPage")]
        public long ResultsPerPage { get; set; }
    }

    public partial class YoutubeSearchResult
    {
        public static YoutubeSearchResult FromJson(string json) => JsonConvert.DeserializeObject<YoutubeSearchResult>(json, Converter.Settings);
    }

    public static class YoutubeSearchResultSerialize
    {
        public static string ToJson(this YoutubeSearchResult self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
