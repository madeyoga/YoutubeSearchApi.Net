using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using YoutubeSearchAPI.Modules;

namespace YoutubeSearchAPI
{
    public class YoutubeSearchClient
    {
        private String developerKey;
        private UrlBuilder urlBuilder;
        private readonly HttpClient httpClient;

        public YoutubeSearchClient(String developerKey)
        {
            this.developerKey = developerKey;
            
            this.httpClient = new HttpClient();
            
            urlBuilder = new UrlBuilder(developerKey);
        }

        private async Task <dynamic> HttpRequestGet(String requestUrl)
        {
            var response = await httpClient.GetAsync(requestUrl);

            String jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
        }

        public async Task <dynamic> Search(String query, String part = "snippet", String type = "Video", int maxResults = 5, int videoCategory = 10)
        {
            String requestUrl = urlBuilder.BuildSearchUrl(query, part, type, maxResults, videoCategory);
            
            return await HttpRequestGet(requestUrl);
        }

        public async Task <dynamic> GetPlayListById(String playlistId, int maxResults = 5, String part = "snippet")
        {
            String requestUrl = urlBuilder.BuildPlayListUrl(playlistId, part: part, maxResults: maxResults);

            return await HttpRequestGet(requestUrl);
        }

        public async Task <dynamic> GetVideoDetail(String videoId)
        {
            String requestUrl = urlBuilder.BuildDetailUrl(videoId: videoId);

            return await HttpRequestGet(requestUrl);
        }
    }
}
