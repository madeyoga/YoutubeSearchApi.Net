using System;
using System.Threading.Tasks;
using YoutubeSearchApi.Net;

namespace Test
{
    class YoutubeApiV3Client_Search
    {
        public static async Task AsyncMain()
        {
            // Never hardcode your api key...
            // Initialize YoutubeSearchClient
            YoutubeApiV3Client ytsClient = new YoutubeApiV3Client(Environment.GetEnvironmentVariable("DEVELOPER_KEY"));

            // Search with maxResults 1 & with keywords "CHiCO Love Letter"
            dynamic responseObject = await ytsClient.Search("CHiCO Love Letter", maxResults: 1);

            // Print the video id & title
            Console.WriteLine("VideoId: " + responseObject["items"][0]["id"]["videoId"]);
            Console.WriteLine("Title:   " + responseObject["items"][0]["snippet"]["title"]);

            // Print entries
            Console.WriteLine(responseObject["items"]);
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}
