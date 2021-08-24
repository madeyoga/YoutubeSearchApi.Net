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
    class Google_Search
    {
        public static async Task AsyncMain()
        {
            using (var httpClient = new HttpClient())
            {
                DefaultSearchClient client = new DefaultSearchClient(new GoogleSearchBackend());

                var response = await client.SearchAsync(httpClient, "articlearn", maxResults: 5);
                foreach(GoogleSearchResult link in response.Results)
                {
                    Console.WriteLine(link);
                }
            }
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}
