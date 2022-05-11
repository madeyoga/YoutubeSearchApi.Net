using Microsoft.Extensions.DependencyInjection;
using YoutubeSearchApi.Net.Services;

namespace YoutubeSearchApi.Net.Extensions
{
    public static class MainServiceExtension
    {
        public static void AddYoutubeSearchClient(this IServiceCollection services)
        {
            services.AddHttpClient<YoutubeSearchClient>();
        }

        public static void AddYoutubeMusicSearchClient(this IServiceCollection services)
        {
            services.AddHttpClient<YoutubeMusicSearchClient>();
        }
    }
}
