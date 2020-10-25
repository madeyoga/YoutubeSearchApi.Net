using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApiNet;
using YoutubeSearchApiNet.Objects;

namespace Test
{
    class TestYoutubeClient
    {
        public static async Task AsyncMain()
        {
            HttpClient httpClient = new HttpClient();

            // Initialize YoutubeClient
            YoutubeClient ytClient = new YoutubeClient(httpClient);

            // Search with maxResults 1 & with keywords "CHiCO Love Letter"
            List<YoutubeVideo> responseObject = await ytClient.Search("CHiCO Love Letter", maxResults: 1);

            foreach(YoutubeVideo video in responseObject)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}
