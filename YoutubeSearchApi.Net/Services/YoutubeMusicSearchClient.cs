using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using YoutubeSearchApi.Net.Models.Youtube;

namespace YoutubeSearchApi.Net.Services;

public class YoutubeMusicSearchClient : ISearchClient<YoutubeSearchResult>
{
    private static readonly string WATCH_URL_PREFIX = "https://www.youtube.com/watch?v=";
    private static readonly string MUSIC_BASE_URL = "https://music.youtube.com/youtubei/v1";
    private static readonly string MUSIC_API_KEY = "AIzaSyC9XL3ZjWddXya6X74dJoCTL-WEYFDNX30";
    private static readonly string MUSIC_CLIENT_NAME = "WEB_REMIX";
    private static readonly string MUSIC_CLIENT_VERSION = "0.1";
    private static readonly string MUSIC_BASE_PAYLOAD = "{\"context\":{\"client\":{\"clientName\":\"" + MUSIC_CLIENT_NAME + "\",\"clientVersion\":\"" + MUSIC_CLIENT_VERSION + "\"}},";
    private static readonly string MUSIC_SEARCH_URL = MUSIC_BASE_URL + "/search?key=" + MUSIC_API_KEY;
    private static readonly string MUSIC_SEARCH_PAYLOAD = MUSIC_BASE_PAYLOAD + "\"query\":\"%s\",\"params\":\"Eg-KAQwIARAAGAAgACgAMABqChADEAQQCRAFEAo=\"}";
    private readonly HttpClient httpClient;

    public YoutubeMusicSearchClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
        this.httpClient.DefaultRequestHeaders.Add("Referer", "music.youtube.com");
    }

    public YoutubeSearchResult Search(string query, int retry = 3)
    {
        throw new System.NotImplementedException();
    }

    public async Task<YoutubeSearchResult> SearchAsync(string query, int retry = 3)
    {
        query = HttpUtility.UrlEncode(query);
        
        var content = new StringContent(MUSIC_SEARCH_PAYLOAD.Replace("%s", query), Encoding.UTF8);
        
        var response = await httpClient.PostAsync(MUSIC_SEARCH_URL, content);
        
        var videos = ParseData(await response.Content.ReadAsStringAsync());

        return new YoutubeSearchResult
        {
            Url = MUSIC_SEARCH_URL,
            Query = query,
            Results = videos,
        };
    }

    private List<YoutubeVideo> ParseData(string pageContent)
    {
        var videos = new List<YoutubeVideo>();

        JObject jsonObject = JObject.Parse(pageContent);
        var contents = jsonObject["contents"]["tabbedSearchResultsRenderer"]["tabs"][0]["tabRenderer"]["content"]["sectionListRenderer"]["contents"][0].Value<JObject>();

        if (contents.ContainsKey("musicShelfRenderer"))
        {
            foreach (JObject videoJson in contents["musicShelfRenderer"]["contents"].Value<JArray>())
            {
                JObject renderer = videoJson["musicResponsiveListItemRenderer"]["overlay"]["musicItemThumbnailOverlayRenderer"].Value<JObject>();
                string videoId = renderer["content"]["musicPlayButtonRenderer"]["playNavigationEndpoint"]["watchEndpoint"]["videoId"].Value<string>();

                string title = renderer["content"]["musicPlayButtonRenderer"]["accessibilityPauseData"]["accessibilityData"]["label"].Value<string>();
                List<string> titleList = title.Split().ToList();
                titleList.RemoveAt(0);
                title = string.Join(" ", titleList.ToArray());

                JArray flexColumns = videoJson["musicResponsiveListItemRenderer"]["flexColumns"][1]["musicResponsiveListItemFlexColumnRenderer"]["text"]["runs"].Value<JArray>();
                var element = (JObject)flexColumns.First();
                string author = element["text"].Value<string>();

                element = (JObject)flexColumns.Last();
                string duration = element["text"].Value<string>();

                var video = new YoutubeVideo(videoId, $"{WATCH_URL_PREFIX}{videoId}", title, "#", duration, author);
                videos.Add(video);
            }
        }

        return videos;
    }
}
