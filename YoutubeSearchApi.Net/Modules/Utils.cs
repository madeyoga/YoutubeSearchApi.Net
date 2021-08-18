using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeSearchApi.Net.Modules
{
    public class Utils
    {
        public static dynamic DecodeJson(string jsonString)
            => JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

        public static async Task <dynamic> HttpRequestGetJson(HttpClient httpClient, string requestUrl)
        {
            var response = await httpClient.GetAsync(requestUrl);

            string jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        }

        public static async Task <string> GetSourceFromUrl(HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);

            string pageString = await response.Content.ReadAsStringAsync();

            return pageString;
        }

        public static string UrlEncodeDictionary(IDictionary<string, object> dict)
        {
            var list = new List<string>();
            foreach (var item in dict)
            {
                list.Add(item.Key + "=" + item.Value);
            }
            return string.Join("&", list);
        }
    }
}
