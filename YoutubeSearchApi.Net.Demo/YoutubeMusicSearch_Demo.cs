namespace YoutubeSearchApi.Net.Demo;

using YoutubeSearchApi.Net.Models.Youtube;
using YoutubeSearchApi.Net.Services;

internal class YoutubeMusicSearch_Demo
{
    public static async Task AsyncMain()
    {
        using (var httpClient = new HttpClient())
        {
            YoutubeMusicSearchClient client = new YoutubeMusicSearchClient(httpClient);

            var responseObject = await client.SearchAsync("simple ringtone");

            foreach (YoutubeVideo video in responseObject.Results)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }
        }
    }

    public static void Main(string[] args) => AsyncMain().GetAwaiter().GetResult();
}
