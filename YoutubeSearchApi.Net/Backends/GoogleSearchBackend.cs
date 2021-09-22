using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using YoutubeSearchApi.Net.Modules;
using YoutubeSearchApi.Net.Objects;

namespace YoutubeSearchApi.Net.Backends
{
    public class GoogleSearchBackend : ISearchBackend
    {
        static string BASE_URL = "https://www.google.com/search?";

        public DefaultResponse ParseData(string pageContent, int maxResults)
        {
            var results = new List<IResponseResult>();

            var doc = new HtmlDocument();
            doc.LoadHtml(pageContent);

            var nodes = doc.DocumentNode.Descendants("a");

            foreach (var node in nodes)
            {
                string href = node.GetAttributeValue("href", "#");

                if (href.StartsWith("/url?q="))
                {
                    string link = href.Substring(7, href.IndexOf("&amp;sa") - 7);

                    // Title
                    var headerNodes = node.Descendants("h3");
                    string title = "";
                    if (headerNodes.Count() > 0)
                    {
                        title = headerNodes.First().Descendants("div").First().InnerText;
                    }

                    // Description
                    var rootNode = node.ParentNode.ParentNode;
                    var childs = rootNode.Descendants("div");

                    string description = "";
                    if (childs.Count() > 0)
                    {
                        description = childs.Last().InnerHtml;
                    }

                    var googleResult = new GoogleSearchResult(link, title, "", description);
                    results.Add(googleResult);
                }
            }

            return new DefaultResponse(BASE_URL, "#", results);
        }

        public async Task<string> RequestDataAsync(HttpClient httpClient, string query, int retry = 3, Dictionary<string, object> extras = null)
        {
            var parameters = new Dictionary<string, object>
            {
                { "q", query },
                { "start", "0" },
            };

            string url = BASE_URL + Utils.UrlEncodeDictionary(parameters);

            var response = await httpClient.GetAsync(url);

            string pageContent = await response.Content.ReadAsStringAsync();

            return pageContent;
        }
    }
}
