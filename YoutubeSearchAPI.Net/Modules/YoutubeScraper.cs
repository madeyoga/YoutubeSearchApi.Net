using System;
using System.Net.Http;
using System.Web;

namespace YoutubeSearchAPI.Modules
{
    class YoutubeScraper
    {
        private string baseUrl = "https://youtube.com";
        private readonly HttpClient httpClient;

        public YoutubeScraper()
        {
            httpClient = new HttpClient();
        }

        public String GetBaseYoutubePage()
            => Utils.GetSourceFromUrl(baseUrl);

        public String GetYoutubeSearchPage(String query)
        {
            String encodedQuery = HttpUtility.UrlEncode(query);
            return Utils.GetSourceFromUrl($"{baseUrl}/results?search_query={encodedQuery}");
        }

        public dynamic ParseSearchHtml(String searchPage)
        {
            return "";
        }
    }
}
