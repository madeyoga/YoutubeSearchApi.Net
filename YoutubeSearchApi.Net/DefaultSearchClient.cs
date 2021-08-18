using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net.Backends;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net
{
    public class DefaultSearchClient : ISearchClient
    {
        public ISearchBackend SearchBackend { get; set; }

        public DefaultSearchClient(ISearchBackend searchClient)
        {
            SearchBackend = searchClient;
        }

        public async Task<IResponseObject> SearchAsync(HttpClient httpClient, string query, int maxResults, int retry = 3, Dictionary<string, object> extras = null)
        {
            string pageContent = await SearchBackend.RequestDataAsync(httpClient, query, retry, extras);
            return SearchBackend.ParseData(pageContent, maxResults);
        }
    }
}
