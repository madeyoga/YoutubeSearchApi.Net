# YoutubeSearchApi.Net
![CodeFactor Grade](https://img.shields.io/codefactor/grade/github/madeyoga/YoutubeSearchApi.Net?style=for-the-badge)
[![Nuget](https://img.shields.io/nuget/dt/YoutubeSearchApi.Net?color=GREEN&style=for-the-badge)](https://www.nuget.org/packages/YoutubeSearchApi.Net/)
[![contributionswelcome](https://img.shields.io/badge/contributions-welcome-brightgreen/?style=for-the-badge)](https://github.com/madeyoga/YoutubeSearchApi.Net/issues)
[![discord_invite](https://img.shields.io/discord/458296099049046018?style=for-the-badge)](https://discord.gg/Y8sB4ay)

A lightweight & simple .NET library to extract data from Youtube.
The purpose of this project is to make it easier for developers to extract data from YouTube or any sources.


## Supported Sites
- Youtube
- Youtube Music

## Installation

### NuGet
- [YoutubeSearchApi.Net](https://www.nuget.org/packages/YoutubeSearchApi.Net/)


## Quick Start
**Youtube Search**
```C#
using YoutubeSearchApi.Net.Models.Youtube;
using YoutubeSearchApi.Net.Services;

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

public static void Main(string[] args)
{
    AsyncMain().GetAwaiter().GetResult();
}
```

**Youtube Music Search**
```C#
using YoutubeSearchApi.Net.Models.Youtube;
using YoutubeSearchApi.Net.Services;

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

public static void Main(string[] args)
{
    AsyncMain().GetAwaiter().GetResult();
}
```

[Full examples at Demo project](https://github.com/madeyoga/YoutubeSearchApi.Net/tree/master/YoutubeSearchApi.Net.Demo)

## Using Service Collection
```cs
services.AddHttpClient<YoutubeSearchClient>();
services.AddHttpClient<YoutubeMusicSearchClient>();


// MyController.cs

private readonly YoutubeSearchClient ytClient;
private readonly YoutubeMusicSearchClient ytmClient;

public MyController(YoutubeSearchClient ytClient, YoutubeMusicSearchClient ytmClient)
{
    this.ytClient = ytClient;
    this.ytmClient = ytmClient;
}
```

## Contributing
Issues and Pull requests are very welcome. Feel free to open issues and pull requests.
