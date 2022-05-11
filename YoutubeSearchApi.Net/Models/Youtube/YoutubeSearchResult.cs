using System.Collections.Generic;

namespace YoutubeSearchApi.Net.Models.Youtube
{
    public class YoutubeSearchResult
    {
        public string Url { get; set; }
        public string Query { get; set; }
        public ICollection<YoutubeVideo> Results { get; set; }
    }
}
