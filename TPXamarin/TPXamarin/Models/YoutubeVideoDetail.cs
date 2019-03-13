using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;

namespace TPXamarin.Models
{
    public partial class YoutubeVideoDetail
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("pageInfo")]
        public YoutubeVideoDetailPageInfo YoutubeVideoDetailPageInfo { get; set; }

        [JsonProperty("items")]
        public YoutubeVideoDetailItem[] YoutubeVideoDetailItems { get; set; }
    }

    public partial class YoutubeVideoDetailItem
    {
        [JsonProperty("kind")]
        public string Kind { get; set; }

        [JsonProperty("etag")]
        public string Etag { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("snippet")]
        public YoutubeVideoDetailSnippet YoutubeVideoDetailSnippet { get; set; }

        [JsonProperty("statistics")]
        public YoutubeVideoDetailStatistics YoutubeVideoDetailStatistics { get; set; }

        [JsonProperty("player")]
        public YoutubeVideoDetailPlayer YoutubeVideoDetailPlayer { get; set; }
    }

    public partial class YoutubeVideoDetailPlayer
    {
        [JsonProperty("embedHtml")]
        public string EmbedHtml { get; set; }
    }

    public partial class YoutubeVideoDetailSnippet
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
        public YoutubeVideoDetailThumbnails YoutubeVideoDetailThumbnails { get; set; }

        [JsonProperty("channelTitle")]
        public string ChannelTitle { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("categoryId")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CategoryId { get; set; }

        [JsonProperty("liveBroadcastContent")]
        public string LiveBroadcastContent { get; set; }

        [JsonProperty("localized")]
        public YoutubeVideoDetailLocalized YoutubeVideoDetailLocalized { get; set; }
    }

    public partial class YoutubeVideoDetailLocalized
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public partial class YoutubeVideoDetailThumbnails
    {
        [JsonProperty("default")]
        public YoutubeVideoDetailDefault YoutubeVideoDetailDefault { get; set; }

        [JsonProperty("medium")]
        public YoutubeVideoDetailDefault Medium { get; set; }

        [JsonProperty("high")]
        public YoutubeVideoDetailDefault High { get; set; }

        [JsonProperty("standard")]
        public YoutubeVideoDetailDefault Standard { get; set; }
    }

    public partial class YoutubeVideoDetailDefault
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }
    }

    public partial class YoutubeVideoDetailStatistics
    {
        [JsonProperty("viewCount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long ViewCount { get; set; }

        [JsonProperty("likeCount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long LikeCount { get; set; }

        [JsonProperty("dislikeCount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long DislikeCount { get; set; }

        [JsonProperty("favoriteCount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long FavoriteCount { get; set; }

        [JsonProperty("commentCount")]
        [JsonConverter(typeof(ParseStringConverter))]
        public long CommentCount { get; set; }
    }

    public partial class YoutubeVideoDetailPageInfo
    {
        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }

        [JsonProperty("resultsPerPage")]
        public long ResultsPerPage { get; set; }
    }

    public partial class YoutubeVideoDetail
    {
        public static YoutubeVideoDetail FromJson(string json) => JsonConvert.DeserializeObject<YoutubeVideoDetail>(json, Converter.Settings);
    }

    public static class YoutubeVideoDetailSerialize
    {
        public static string ToJson(this YoutubeVideoDetail self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class YoutubeVideoDetailConverter
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

    internal class ParseStringConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            long l;
            if (Int64.TryParse(value, out l))
            {
                return l;
            }
            throw new Exception("Cannot unmarshal type long");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (long)untypedValue;
            serializer.Serialize(writer, value.ToString());
            return;
        }

        public static readonly ParseStringConverter Singleton = new ParseStringConverter();
    }
}
