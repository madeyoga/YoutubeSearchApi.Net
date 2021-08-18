using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeSearchApi.Net.Exceptions;
using YoutubeSearchApi.Net.Modules;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net.Backends
{
    public class YoutubeMusicSearchBackend : ISearchBackend
    {
        string BASE_URL { get; }
        string APIKey { get; set; }
        Dictionary<string, object> Parameters { get; }

        public YoutubeMusicSearchBackend(string apikey)
        {
            BASE_URL = "https://music.youtube.com/youtubei/v1/search?";
            APIKey = apikey;

            Parameters = new Dictionary<string, object>();
            Parameters.Add("alt", "json");
            Parameters.Add("key", APIKey);
        }

        public IResponseObject ParseData(string pageContent, int maxResults)
        {

            YoutubeResponse youtubeResponse = new YoutubeResponse();

            JObject jsonObject = JObject.Parse(pageContent);
            var contents = jsonObject["contents"]["tabbedSearchResultsRenderer"]["tabs"][0]["tabRenderer"]["content"]["sectionListRenderer"]["contents"][0].Value<JObject>();

            if (contents.ContainsKey("musicShelfRenderer"))
            {
                foreach(JObject videoJson in contents["musicShelfRenderer"]["contents"].Value<JArray>())
                {
                    JObject renderer = videoJson["musicResponsiveListItemRenderer"]["overlay"]["musicItemThumbnailOverlayRenderer"].Value<JObject>();
                    string videoId = renderer["content"]["musicPlayButtonRenderer"]["playNavigationEndpoint"]["watchEndpoint"]["videoId"].Value<string>();
                    
                    string title = renderer["content"]["musicPlayButtonRenderer"]["accessibilityPauseData"]["accessibilityData"]["label"].Value<string>();
                    List<string> titleList = title.Split().ToList();
                    titleList.RemoveAt(0);
                    title = string.Join(" ", titleList.ToArray());

                    JArray flexColumns = videoJson["musicResponsiveListItemRenderer"]["flexColumns"][1]["musicResponsiveListItemFlexColumnRenderer"]["text"]["runs"].Value<JArray>();
                    var element = (JObject) flexColumns.First();
                    string author = element["text"].Value<string>();

                    element = (JObject) flexColumns.Last();
                    string duration = element["text"].Value<string>();

                    YoutubeVideo video = new YoutubeVideo(videoId, BASE_URL, title, "#", duration, author);
                    youtubeResponse.Results.Add(video);
                }
            }
            return youtubeResponse;
        }

        public async Task<string> RequestDataAsync(HttpClient httpClient, string query, int retry = 3, Dictionary<string, object> extras = null)
        {
            httpClient.DefaultRequestHeaders.Add("Referer", "music.youtube.com");

            string uri = BASE_URL + Utils.UrlEncodeDictionary(Parameters);

            query = HttpUtility.UrlEncode(query);
            string payloadString = "{\"context\":{\"client\":{\"clientName\":\"WEB_REMIX\",\"clientVersion\":\"0.1\"}},\"query\":\"" + query + "\"" +
                ",\"params\":\"Eg-KAQwIARAAGAAgACgAMABqChADEAQQCRAFEAo=\"}";

            var content = new StringContent(payloadString);
            var response = await httpClient.PostAsync(uri, content);
            
            return await response.Content.ReadAsStringAsync();
        }
    }
}
