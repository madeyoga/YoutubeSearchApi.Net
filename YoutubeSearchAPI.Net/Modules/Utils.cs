using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace YoutubeSearchAPI.Modules
{
    public class Utils
    {
        public static dynamic DecodeJson(string jsonString)
            => JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

        public static async Task <dynamic> HttpRequestGet(HttpClient httpClient, string requestUrl)
        {
            var response = await httpClient.GetAsync(requestUrl);

            string jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);
        }

        public static string GetSourceFromUrl(string url)
        {
            string htmlCode = "";

            using (WebClient client = new WebClient())
            {
                htmlCode = client.DownloadString(url);
            }

            return htmlCode;
        }
    }
}
