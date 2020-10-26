using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net;
using YoutubeSearchApi.Net.Objects;

namespace Test
{
    class YoutubeClient_GetRecommendation
    {
        public static async Task AsyncMain()
        {
            HttpClient httpClient = new HttpClient();

            // Initialize YoutubeClient
            YoutubeClient ytClient = new YoutubeClient(httpClient);

            // Get sond PlaylistRecommendation by video Id.
            YoutubePlaylist youtubePlaylist = await ytClient.GetPlaylistRecommendation("9CyMi-n36rg");

            Console.WriteLine(youtubePlaylist);
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}
