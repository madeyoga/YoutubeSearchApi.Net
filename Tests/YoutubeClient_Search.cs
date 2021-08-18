﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net;
using YoutubeSearchApi.Net.Backends;
using YoutubeSearchApi.Net.Objects;

namespace Test
{
    class YoutubeClient_Search
    {
        public static async Task AsyncMain()
        {
            HttpClient httpClient = new HttpClient();
            
            DefaultSearchClient client = new DefaultSearchClient(new YoutubeSearchBackend());

            YoutubeResponse responseObject = (YoutubeResponse) await client.SearchAsync(httpClient, "black suit", maxResults: 5);

            Console.WriteLine("RESPONSE: ");
            foreach(YoutubeVideo video in responseObject.Results)
            {
                Console.WriteLine(video.ToString());
                Console.WriteLine("");
            }

            httpClient.Dispose();
        }

        public static void Main(string[] args)
        {
            AsyncMain().GetAwaiter().GetResult();
        }
    }
}