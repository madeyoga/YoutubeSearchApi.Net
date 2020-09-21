using System;
using YoutubeSearchAPI;

namespace Test
{
    class TestYoutubeSearchClient
    { 
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Never hardcode your api key...
            // Initialize YoutubeSearchClient
            YoutubeSearchClient ytsClient = new YoutubeSearchClient(Environment.GetEnvironmentVariable("DEVELOPER_KEY"));

            // Search with maxResults 1 & with keywords "CHiCO Love Letter"
            dynamic responseObject = await ytsClient.Search("CHiCO Love Letter", maxResults: 1);

            // Print the video id & title
            Console.WriteLine("VideoId: " + responseObject["items"][0]["id"]["videoId"]);
            Console.WriteLine("Title:   " + responseObject["items"][0]["snippet"]["title"]);

            // Print entries
            Console.WriteLine(responseObject["items"]);
        }
    }
}
