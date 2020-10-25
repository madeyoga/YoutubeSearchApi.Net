using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace YoutubeSearchApiNet.Objects
{
    public class YoutubeVideo
    {
        public string Id { get; }
        public string Uri { get; }
        public string Title { get; }
        public string ThumbnailUrl { get; }
        public string Duration { get; }
        public string Author { get; }

        public YoutubeVideo(string Id, string Uri, string Title, string ThumbnailUrl, string Duration, string Author)
        {
            this.Id = Id;
            this.Uri = Uri;
            this.Title = Title;
            this.ThumbnailUrl = ThumbnailUrl;
            this.Duration = Duration;
            this.Author = Author;
        }

        public static YoutubeVideo ParseVideoRenderer(JObject videoRenderer)
        {
            string videoId = videoRenderer["videoId"].Value<string>();
            
            string videoUri = "https://www.youtube.com/watch?v=" + videoId;

            string videoTitle = videoRenderer["title"]["runs"][0]["text"].Value<string>();

            string videoThumbnailUrl = videoRenderer["thumbnail"]["thumbnails"][0]["url"].Value<string>();
            
            string videoDuration = "";
            if (videoRenderer.ContainsKey("lengthText"))
                videoDuration = videoRenderer["lengthText"]["simpleText"].Value<string>().Replace(".", ":");

            string videoAuthor = videoRenderer["longBylineText"]["runs"][0]["text"].Value<string>();

            return new YoutubeVideo(videoId, videoUri, videoTitle, videoThumbnailUrl, videoDuration, videoAuthor);
        }

        public override string ToString()
        {
            return "YoutubeVideo{" +
                "Id='" + Id + '\'' +
                ", Uri='" + Uri + '\'' +
                ", Title='" + Title + '\'' +
                ", ThumbnailUrl='" + ThumbnailUrl + '\'' +
                ", Author='" + Author + '\'' +
                ", Duration='" + Duration + '\'' +
                '}';
        }
    }
}
