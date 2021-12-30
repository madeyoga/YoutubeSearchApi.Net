namespace YoutubeSearchApi.Net.Models.Google;

using System.Collections.Generic;

public class GoogleSearchResult
{
    public string Url { get; set; }
    public string Query { get; set; }
    public ICollection<GoogleResult> Results { get; set; }
}
