# YoutubeSearchApi.Net
![CodeFactor](https://www.codefactor.io/repository/github/madeyoga/youtubesearchapi/badge/master)
![NugetBadge](https://img.shields.io/nuget/v/YoutubeSearchApi)
[![contributionswelcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/madeyoga/YoutubeSearchApi/issues)
[![DiscordBadge](https://discordapp.com/api/guilds/458296099049046018/embed.png)](https://discord.gg/Y8sB4ay)

A lightweight &amp; simple .NET library to extract data from Youtube Data API v3. 
The purpose of this project is to make it easier for developers to extract data from YouTube.


## Requirements
- [Get Google API Credential 'API KEY'](https://developers.google.com/youtube/registering_an_application)

## Installation

### NuGet
- [YoutubeSearchAPI](https://www.nuget.org/packages/YoutubeSearchAPI/)

## Compiling
In order to compile YoutubeSearchApi, you require the following:

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
using YoutubeSearchAPI;

namespace Test
{
    class TestYoutubeSearchClient
    { 
        static async System.Threading.Tasks.Task Main(string[] args)
        {
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
```

### Output
```bash
VideoId: hVUfJioCa0s
Title:   CHiCO with HoneyWorks - Love Letter ~ English Subtitles
```

### Raw ["items"]
```bash
[
  {
    "kind": "youtube#searchResult",
    "etag": "dvGbeGQbn8pnlhltXOGAJUCInek",
    "id": {
      "kind": "youtube#video",
      "videoId": "hVUfJioCa0s"
    },
    "snippet": {
      "publishedAt": "2019-10-30T19:26:41Z",
      "channelId": "UCU9G-F-f_NLxDMAQM6T-r9w",
      "title": "CHiCO with HoneyWorks - Love Letter ~ English Subtitles",
      "description": "Happy Halloween everybody! :D This song is probably my favorite in the album. Too bad it did not become a single. If you listen carefully to the 2nd verse, ...",
      "thumbnails": {
        "default": {
          "url": "https://i.ytimg.com/vi/hVUfJioCa0s/default.jpg",
          "width": 120,
          "height": 90
        },
        "medium": {
          "url": "https://i.ytimg.com/vi/hVUfJioCa0s/mqdefault.jpg",
          "width": 320,
          "height": 180
        },
        "high": {
          "url": "https://i.ytimg.com/vi/hVUfJioCa0s/hqdefault.jpg",
          "width": 480,
          "height": 360
        }
      },
      "channelTitle": "RandomAir BGM",
      "liveBroadcastContent": "none",
      "publishTime": "2019-10-30T19:26:41Z"
    }
  }
]
```
