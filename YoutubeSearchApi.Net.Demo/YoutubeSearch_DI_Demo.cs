using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YoutubeSearchApi.Net.Extensions;
using YoutubeSearchApi.Net.Models.Youtube;
using YoutubeSearchApi.Net.Services;

namespace YoutubeSearchApi.Net.Demo;

internal class YoutubeSearch_DI_Demo
{
    public static void Main(string[] args) => AsyncMain(args).GetAwaiter().GetResult();

    internal static Task AsyncMain(string[] args)
    {
        using IHost host = CreateHostBuilder(args).Build();

        return host.RunAsync();
    }

    internal static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) =>
        {
            services.AddYoutubeSearchClient();
            services.AddYoutubeMusicSearchClient();
            services.AddHostedService<Worker>();
        });
    }

    internal class Worker : BackgroundService
    {
        private readonly YoutubeSearchClient ytClient;
        private readonly YoutubeMusicSearchClient ytmClient;

        public Worker(YoutubeSearchClient ytClient, YoutubeMusicSearchClient ytmClient)
        {
            this.ytClient = ytClient;
            this.ytmClient = ytmClient;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var response = await ytClient.SearchAsync("ringtone");
            Console.WriteLine("YoutubeSearchClient Result:");
            foreach (YoutubeVideo video in response.Results)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }
            
            Console.WriteLine("");

            response = await ytmClient.SearchAsync("test ringtone");
            Console.WriteLine("YoutubeMusicSearchClient Result:");
            foreach (YoutubeVideo video in response.Results)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }
        }
    }
}
