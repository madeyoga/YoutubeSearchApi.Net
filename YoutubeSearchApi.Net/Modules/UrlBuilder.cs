using System;
using System.Web;

namespace YoutubeSearchApi.Net.Modules
{
    public class UrlBuilder
    {
        private static readonly string baseUrl = "https://www.googleapis.com/youtube/v3";
        private string baseSearchUrl = $"{baseUrl}/search/?key=";
        private string baseVideoDetailUrl = $"{baseUrl}/videos?key=";
        private string basePlaylistUrl = $"{baseUrl}/playlistItems?key=";
        private string baseCommentThreadsUrl = $"{baseUrl}/commentThreads?key=";

        public UrlBuilder(string developerKey)
        {
            baseSearchUrl += developerKey;
            baseVideoDetailUrl += developerKey;
            basePlaylistUrl += developerKey;
            baseCommentThreadsUrl += developerKey;
        }

        public string BuildSearchUrl(string query, string part = "snippet", string type = "Video", int maxResults = 5, int videoCategory = 10)
        {
            string encodedQuery = HttpUtility.UrlEncode(query);
            
            string searchUrl = $"{baseSearchUrl}&q={encodedQuery}&part={part}&type={type}&maxResults={maxResults}";

            return searchUrl;
        }

        public string BuildVideoDetailUrl(string videoId)
            => $"{baseVideoDetailUrl}&id={videoId}&part=contentDetails";

        public string BuildPlaylistUrl(string playlistId, string part = "snippet", int maxResults = 7)
            => $"{basePlaylistUrl}&part={part}&maxResults={maxResults}&playlistId={playlistId}";

        public string BuildVideoCommentThreadsUrl(string videoId, int maxResults = 5, string textFormat = "plainText", string part = "snippet")
            => $"{baseCommentThreadsUrl}&videoId={videoId}&maxResults={maxResults}&textFormat={textFormat}&part={part}";

        public string BuildChannelCommentThreadsUrl(string channelId, int maxResults = 5, string textFormat = "plainText", string part = "snippet")
            => $"{baseCommentThreadsUrl}&channelId={channelId}&maxResults={maxResults}&textFormat={textFormat}&part={part}";
    }
}
