using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net.Backends
{
    public interface ISearchBackend
    {
        DefaultResponse ParseData(string pageContent, int maxResults);
        Task<string> RequestDataAsync(HttpClient httpClient, string query, int retry = 3, Dictionary<string, object> extras = null);
    }
}
