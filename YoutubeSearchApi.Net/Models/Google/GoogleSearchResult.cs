using System.Collections.Generic;

namespace YoutubeSearchApi.Net.Models.Google
{
    public class GoogleSearchResult
    {
        public string Url { get; set; }
        public string Query { get; set; }
        public ICollection<GoogleResult> Results { get; set; }
    }
}