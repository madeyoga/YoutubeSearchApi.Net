using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace YoutubeSearchAPI.Modules
{
    public class Utils
    {
        public static dynamic DecodeJson(String jsonString)
            => JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);

        public static async Task <dynamic> HttpRequestGet(HttpClient httpClient, String requestUrl)
        {
            var response = await httpClient.GetAsync(requestUrl);

            String jsonString = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<Dictionary<String, object>>(jsonString);
        }

        public static String GetSourceFromUrl(String url)
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
