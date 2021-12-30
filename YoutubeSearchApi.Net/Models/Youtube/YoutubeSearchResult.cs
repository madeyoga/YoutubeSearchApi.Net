namespace YoutubeSearchApi.Net.Models.Youtube;

using System.Collections.Generic;

public class YoutubeSearchResult
{
    public string Url { get; set; }
    public string Query { get; set; }
    public ICollection<YoutubeVideo> Results { get; set; }
}
