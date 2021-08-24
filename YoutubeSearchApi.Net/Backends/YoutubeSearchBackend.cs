using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeSearchApi.Net.Exceptions;
using YoutubeSearchApi.Net.Modules;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net.Backends
{
    public class YoutubeSearchBackend : ISearchBackend
    {
        string BASE_URL { get; }

        public YoutubeSearchBackend()
        {
            BASE_URL = "https://www.youtube.com/results?search_query=";
        }

        public DefaultResponse ParseData(string pageContent, int maxResults)
        {
            string startFeature = "ytInitialData";

            // Get index of start feature + startFeature.Length + 3 
            // to get rid of the startFeature text and the " = " (Get only the Json object)
            int startIndex = pageContent.IndexOf(startFeature) + startFeature.Length + 3;

            // Define startIndex To end page string
            string startIndexToEndPage = pageContent.Substring(startIndex, pageContent.Length - startIndex);

            // And get the first endFeature occurance. endFeature: "};".
            // index + 1 to get the close curly bracket
            int endIndex = startIndexToEndPage.IndexOf("};") + 1;

            string jsonString = startIndexToEndPage.Substring(0, endIndex);

            JObject jsonObject = JObject.Parse(jsonString);

            JArray contents = jsonObject["contents"]["twoColumnSearchResultsRenderer"]
                ["primaryContents"]["sectionListRenderer"]
                ["contents"][0]
                ["itemSectionRenderer"]["contents"].Value<JArray>();

            var youtubeResponses = new List<IResponseResult>();

            int counter = 0;
            foreach (JObject element in contents)
            {
                if (element.ContainsKey("videoRenderer"))
                {
                    JObject videoRenderer = element["videoRenderer"].Value<JObject>();

                    string videoId = videoRenderer["videoId"].Value<string>();

                    string videoUri = "https://www.youtube.com/watch?v=" + videoId;

                    string videoTitle = videoRenderer["title"]["runs"][0]["text"].Value<string>();

                    string videoThumbnailUrl = videoRenderer["thumbnail"]["thumbnails"][0]["url"].Value<string>();

                    string videoDuration = "";
                    if (videoRenderer.ContainsKey("lengthText"))
                        videoDuration = videoRenderer["lengthText"]["simpleText"].Value<string>().Replace(".", ":");

                    string videoAuthor = videoRenderer["longBylineText"]["runs"][0]["text"].Value<string>();

                    YoutubeVideo youtubeVideo = new YoutubeVideo(videoId, videoUri, videoTitle, videoThumbnailUrl, videoDuration, videoAuthor);
                    youtubeResponses.Add(youtubeVideo);

                    counter += 1;
                    if (counter >= maxResults)
                    {
                        break;
                    }
                }
            }
            return new DefaultResponse("#", "", youtubeResponses);
        }

        public async Task<string> RequestDataAsync(HttpClient httpClient, string query, int retry = 3, Dictionary<string, object> extras = null)
        {
            string startFeature = "ytInitialData";
            string encodedKeywords = HttpUtility.UrlEncode(query);
            string searchUrl = BASE_URL + encodedKeywords;

            string pageContent = "";
            bool foundFeatureFlag = false;

            // Try request n times, if still doesn't get the start feature, then throw error
            for (int i = 0; i < retry; i++)
            {
                pageContent = await Utils.GetSourceFromUrl(httpClient, searchUrl);
                if (pageContent.Contains(startFeature))
                {
                    foundFeatureFlag = true;
                    break;
                }
            }
            if (foundFeatureFlag == false)
            {
                throw new NoResultFoundException("What you searched was unfortunately not found or doesn't exist. query: " + query);
            }
            return pageContent;
        }
    }
}
