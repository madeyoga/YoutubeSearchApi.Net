namespace YoutubeSearchApi.Net.Demo;

using YoutubeSearchApi.Net.Models.Youtube;
using YoutubeSearchApi.Net.Services;

internal class YoutubeSearch_Demo
{
    public static async Task AsyncMain()
    {
        using (var httpClient = new HttpClient())
        {
            YoutubeSearchClient client = new YoutubeSearchClient(httpClient);

            var responseObject = await client.SearchAsync("black suit");

            foreach (YoutubeVideo video in responseObject.Results)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }
        }
    }

    public static void Main(string[] args) => AsyncMain().GetAwaiter().GetResult();
}
