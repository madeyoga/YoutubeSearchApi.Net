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

            // Search with maxResults 1 & with keywords "CHiCO with Honeyworks"
            dynamic responseObject = await ytsClient.Search("CHiCO with Honeyworks", maxResults: 1);

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
VideoId: K2pCnvLXdks
Title:   CHiCO with HoneyWorks - ?????????? / THE FIRST TAKE
```

### Output Raw
```bash
[
  {
    "kind": "youtube#searchResult",
    "etag": "zwODij6h3fo6eO9a-CjM0eWLGu0",
    "id": {
      "kind": "youtube#video",
      "videoId": "K2pCnvLXdks"
    },
    "snippet": {
      "publishedAt": "2020-09-18T13:00:12Z",
      "channelId": "UC9zY_E8mcAo_Oq772LEZq8Q",
      "title": "CHiCO with HoneyWorks - ?????????? / THE FIRST TAKE",
      "description": "?THE FIRST TAKE???????????????????????YouTube?????? ONE TAKE ONLY, ONE LIFE ONLY. ?????????????? ?55? ...",
      "thumbnails": {
        "default": {
          "url": "https://i.ytimg.com/vi/K2pCnvLXdks/default.jpg",
          "width": 120,
          "height": 90
        },
        "medium": {
          "url": "https://i.ytimg.com/vi/K2pCnvLXdks/mqdefault.jpg",
          "width": 320,
          "height": 180
        },
        "high": {
          "url": "https://i.ytimg.com/vi/K2pCnvLXdks/hqdefault.jpg",
          "width": 480,
          "height": 360
        }
      },
      "channelTitle": "THE FIRST TAKE",
      "liveBroadcastContent": "none",
      "publishTime": "2020-09-18T13:00:12Z"
    }
  },
]
```
