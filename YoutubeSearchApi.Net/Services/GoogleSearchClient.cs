namespace YoutubeSearchApi.Net.Services;

using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using YoutubeSearchApi.Net.Models.Google;
using YoutubeSearchApi.Net.Modules;

public class GoogleSearchClient : ISearchClient<GoogleSearchResult>
{
    private static readonly string GOOGLE_SEARCH_PREFIX = "https://www.google.com/search?";
    private readonly HttpClient httpClient;

    public GoogleSearchClient(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    public GoogleSearchResult Search(string query, int retry = 3)
    {
        throw new System.NotImplementedException();
    }

    public async Task<GoogleSearchResult> SearchAsync(string query, int retry = 3)
    {
        var parameters = new Dictionary<string, object>
            {
                { "q", query },
                { "start", "0" },
            };

        string url = $"{GOOGLE_SEARCH_PREFIX}{Utils.UrlEncodeDictionary(parameters)}";

        var response = await httpClient.GetAsync(url);

        string pageContent = await response.Content.ReadAsStringAsync();

        return new GoogleSearchResult
        {
            Url = url,
            Query = query,
            Results = ParseData(pageContent),
        };
    }

    private List<GoogleResult> ParseData(string pageContent)
    {
        var results = new List<GoogleResult>();

        //var doc = new HtmlDocument();
        //doc.LoadHtml(pageContent);

        //var nodes = doc.DocumentNode.Descendants("a");

        //foreach (var node in nodes)
        //{
        //    string href = node.GetAttributeValue("href", "#");

        //    if (href.StartsWith("/url?q="))
        //    {
        //        string link = href.Substring(7, href.IndexOf("&amp;sa") - 7);

        //        // Title
        //        var headerNodes = node.Descendants("h3");
        //        string title = "";
        //        if (headerNodes.Count() > 0)
        //        {
        //            title = headerNodes.First().Descendants("div").First().InnerText;
        //        }

        //        // Description
        //        var rootNode = node.ParentNode.ParentNode;
        //        var childs = rootNode.Descendants("div");

        //        string description = "";
        //        if (childs.Count() > 0)
        //        {
        //            description = childs.Last().InnerHtml;
        //        }

        //        var googleResult = new GoogleResult(link, title, "", description);
        //        results.Add(googleResult);
        //    }
        //}
        return results;
    }
}
