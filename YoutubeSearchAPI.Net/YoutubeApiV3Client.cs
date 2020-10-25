using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApiNet.Modules;

namespace YoutubeSearchApiNet
{
    public class YoutubeApiV3Client
    {
        private string developerKey;
        private UrlBuilder urlBuilder;
        private readonly HttpClient httpClient;

        public YoutubeApiV3Client(string developerKey)
        {
            this.developerKey = developerKey;

            httpClient = new HttpClient();

            urlBuilder = new UrlBuilder(developerKey);
        }

        public async Task<dynamic> Search(string query, string part = "snippet", string type = "Video", int maxResults = 5, int videoCategory = 10)
        {
            string requestUrl = urlBuilder.BuildSearchUrl(query, part, type, maxResults, videoCategory);

            return await Utils.HttpRequestGetJson(httpClient, requestUrl);
        }

        public async Task<dynamic> GetPlaylist(string playlistId, int maxResults = 5, string part = "snippet")
        {
            string requestUrl = urlBuilder.BuildPlaylistUrl(playlistId, part: part, maxResults: maxResults);

            return await Utils.HttpRequestGetJson(httpClient, requestUrl);
        }

        public async Task<dynamic> GetVideoDetails(string videoId, List<string> part)
        {
            string requestUrl = urlBuilder.BuildVideoDetailUrl(videoId: videoId);

            return await Utils.HttpRequestGetJson(httpClient, requestUrl);
        }

        public async Task<dynamic> GetVideoCommentThreads(string videoId, int maxResults = 5, string textFormat = "plainText", string part = "snippet")
        {
            string requestUrl = urlBuilder.BuildVideoCommentThreadsUrl(videoId: videoId,
                maxResults: maxResults, textFormat: textFormat, part: part);

            return await Utils.HttpRequestGetJson(httpClient, requestUrl);
        }

        public async Task<dynamic> GetChannelCommentThreads(string channelId, int maxResults = 5, string textFormat = "plainText", string part = "snippet")
        {
            string requestUrl = urlBuilder.BuildChannelCommentThreadsUrl(channelId: channelId,
                maxResults: maxResults, textFormat: textFormat, part: part);

            return await Utils.HttpRequestGetJson(httpClient, requestUrl);
        }
    }
}
