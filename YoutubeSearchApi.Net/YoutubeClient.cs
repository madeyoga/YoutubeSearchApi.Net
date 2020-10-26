using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using YoutubeSearchApi.Net.Exceptions;
using YoutubeSearchApi.Net.Modules;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net
{
    public class YoutubeClient
    {
        private string YOUTUBE_BASE_URL;
        private HttpClient httpClient;

        public YoutubeClient(HttpClient httpClient)
        {
            YOUTUBE_BASE_URL = "https://www.youtube.com/";
            this.httpClient = httpClient;
        }

        public async Task<List<YoutubeVideo>> Search(String keywords, int maxResults)
        {
            string startFeature = "ytInitialData";
            string encodedKeywords = HttpUtility.UrlEncode(keywords);
            string searchUrl = YOUTUBE_BASE_URL + "results?search_query=" + encodedKeywords;

            string pageContent = "";
            bool foundFeatureFlag = false;

            // Try request 3 times, if still doesn't get the start feature, then throw error
            for (int i = 0; i < 3; i++)
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
                throw new NoResultFoundException("What you searched was unfortunately not found or doesn't exist. keywords: " + keywords);
            }

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

            List<YoutubeVideo> searchResults = new List<YoutubeVideo>();
            int counter = 0;
            foreach (JObject element in contents)
            {
                if (element.ContainsKey("videoRenderer"))
                {
                    JObject videoRenderer = element["videoRenderer"].Value<JObject>();
                    YoutubeVideo youtubeVideo = YoutubeVideo.ParseVideoRenderer(videoRenderer);
                    searchResults.Add(youtubeVideo);

                    counter += 1;
                    if (counter >= maxResults)
                    {
                        break;
                    }
                }
            }

            return searchResults;
        }

        public async Task<YoutubePlaylist> GetPlaylistRecommendation(string videoId)
        {
            string requestUrl = YOUTUBE_BASE_URL + "watch?v=" + videoId;
            
            string pageContent = await Utils.GetSourceFromUrl(httpClient, requestUrl);

            string regexPattern = "\"compactRadioRenderer\"(.+?)\"compactVideoRenderer\"";

            Match matcher = Regex.Match(pageContent, regexPattern, RegexOptions.IgnoreCase);

            if (matcher.Success)
            {
                string compactRadioRenderer = matcher.Value;

                // Get Json String
                compactRadioRenderer = "{" + 
                    compactRadioRenderer.Substring(0, compactRadioRenderer.Length - ",{\"compactVideoRenderer\"".Length);

                JObject compactRadioRendererObject = JObject.Parse(compactRadioRenderer)["compactRadioRenderer"].Value<JObject>();

                return YoutubePlaylist.ParseCompactRadioRenderer(compactRadioRendererObject);
            }

            throw new NoResultFoundException("Cannot find any recommendation for videoId: " + videoId);
        }
    }
}
