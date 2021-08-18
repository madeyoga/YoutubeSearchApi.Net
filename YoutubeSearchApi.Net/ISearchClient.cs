using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net
{
    public interface ISearchClient
    {
        Task<IResponseObject> SearchAsync(HttpClient httpClient, string query, int maxResults, int retry = 3, Dictionary<string, object> extras = null);
    }
}
