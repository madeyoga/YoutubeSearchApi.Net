using System;
using System.Web;

namespace YoutubeSearchAPI.Modules
{
    public class UrlBuilder
    {
        private static readonly String baseUrl = "https://www.googleapis.com/youtube/v3";
        private String baseSearchUrl = $"{baseUrl}/search/?key=";
        private String baseDetailUrl = $"{baseUrl}/videos?key=";
        private String basePlayListUrl = $"{baseUrl}/playlistItems?key=";

        public UrlBuilder(String developerKey)
        {
            baseSearchUrl += developerKey;
            baseDetailUrl += developerKey;
            basePlayListUrl += developerKey;
        }

        public String BuildSearchUrl(String query, String part = "snippet", String type = "Video", int maxResults = 5, int videoCategory = 10)
        {
            String encodedQuery = HttpUtility.UrlEncode(query);
            
            String searchUrl = $"{baseSearchUrl}&q={encodedQuery}&part={part}&type={type}&maxResults={maxResults}";

            return searchUrl;
        }

        public String BuildDetailUrl(String videoId)
            => $"{baseDetailUrl}&id={videoId}&part=contentDetails";

        public String BuildPlayListUrl(String playlistId, String part = "snippet", int maxResults = 7)
            => $"{basePlayListUrl}&part={part}&maxResults={maxResults}&playlistId={playlistId}";
    }
}
