using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    public class DefaultResponse
    {
        public string Url { get; }
        public string Query { get; }
        public ICollection<IResponseResult> Results { get; }

        public DefaultResponse(string url, string query, ICollection<IResponseResult> results)
        {
            Url = url;
            Query = query;
            Results = results;
        }

        public DefaultResponse(ICollection<IResponseResult> results)
        {
            Results = results;
        }
    }
}
