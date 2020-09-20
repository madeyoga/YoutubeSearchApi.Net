using System;
using YoutubeSearchAPI;

namespace Test
{
    class TestSearchVideo
    { 
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            // Never hardcode your api key...
            YoutubeSearchClient ytsClient = new YoutubeSearchClient(Environment.GetEnvironmentVariable("DEVELOPER_KEY"));

            dynamic responseObject = await ytsClient.Search("TWICE - Feel Special", maxResults: 1);

            Console.WriteLine(responseObject["items"][0]["id"]["videoId"]);
        }
    }
}
