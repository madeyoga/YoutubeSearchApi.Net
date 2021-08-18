using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    public class YoutubePlaylist
    {
        public string Id { get; }
        public string Uri { get; }
        public string Title { get; }
        public string ThumbnailUrl { get; }
        public string MetadataUrl { get; }

        public YoutubePlaylist(string Id, string Uri, string Title, string ThumbnailUrl, string MetadataUrl)
        {
            this.Id = Id;
            this.Uri = Uri;
            this.Title = Title;
            this.ThumbnailUrl = ThumbnailUrl;
            this.MetadataUrl = MetadataUrl;
        }

        public static YoutubePlaylist ParseCompactRadioRenderer(JObject compactRadioRendererObject)
        {
            string playlistId = compactRadioRendererObject["playlistId"].Value<string>();

            string thumbnailUrl = compactRadioRendererObject["thumbnail"]["thumbnails"][0]["url"].Value<string>();

            string playlistTitle = compactRadioRendererObject["title"]["simpleText"].Value<string>();

            string playlistUrl = compactRadioRendererObject["shareUrl"].Value<string>().Replace("\\u0026", "&");

            string metadataUrl = compactRadioRendererObject["navigationEndpoint"]["commandMetadata"]
                ["webCommandMetadata"]["url"].Value<string>().Replace("\\u0026", "&");

            return new YoutubePlaylist(playlistId, playlistUrl, playlistTitle, thumbnailUrl, metadataUrl);
        }

        public override string ToString()
        {
            return "YoutubePlaylist{" +
                "Id='" + Id + '\'' +
                ", Url='" + Uri + '\'' +
                ", Title='" + Title + '\'' +
                ", ThumbnailUrl='" + ThumbnailUrl + '\'' +
                ", MetadataUrl='" + MetadataUrl + '\'' +
                '}';
        }
    }
}
