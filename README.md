# YoutubeSearchApi.Net
[![CodeFactor](https://www.codefactor.io/repository/github/madeyoga/youtubesearchapi.net/badge)](https://www.codefactor.io/repository/github/madeyoga/youtubesearchapi.net)
[![contributionswelcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/madeyoga/YoutubeSearchApi/issues)
[![DiscordBadge](https://discordapp.com/api/guilds/458296099049046018/embed.png)](https://discord.gg/Y8sB4ay)

A lightweight &amp; simple .NET library to extract data from Youtube, with Scrape client or Youtube Data API v3 client.
The purpose of this project is to make it easier for developers to extract data from YouTube.

## Requirements
- [Get Google API Credential 'API KEY'](https://developers.google.com/youtube/registering_an_application) only for **YoutubeDataApiV3Client**

## Installation

### NuGet
- [YoutubeSearchApi.Net](https://www.nuget.org/packages/YoutubeSearchApi.Net/)

## Compiling
In order to compile YoutubeSearchApi.Net, you require the following:

### Using Visual Studio
- [Visual Studio 2019](https://dotnet.microsoft.com/download#windowsvs2019)
- [.NET Core SDK](https://dotnet.microsoft.com/download)

### Using Command Line
- [.NET Core SDK](https://dotnet.microsoft.com/download)

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## Quick Start
```C#
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
```

Full [examples at Test project](https://github.com/madeyoga/YoutubeSearchApi.Net/tree/master/Test)
