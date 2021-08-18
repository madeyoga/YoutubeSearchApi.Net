using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net;
using YoutubeSearchApi.Net.Backends;
using YoutubeSearchApi.Net.Objects;

namespace Test
{
    class YoutubeMusic_Search
    {
        public static async Task AsyncMain()
        {
            HttpClient httpClient = new HttpClient();

            string key = Environment.GetEnvironmentVariable("YT_MUSIC_KEY");
            DefaultSearchClient client = new DefaultSearchClient(new YoutubeMusicSearchBackend(key));

            var response = (YoutubeResponse) await client.SearchAsync(httpClient, "black suit", maxResults: 5);

            foreach (YoutubeVideo video in response.Results)
            {
                Console.WriteLine(video);
            }

            httpClient.Dispose();
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}
