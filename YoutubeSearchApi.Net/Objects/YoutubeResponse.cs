using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    public class YoutubeResponse : IResponseObject
    {
        public string Url { get; }

        public List<object> Results { get; set; }

        public YoutubeResponse()
        {
            Results = new List<object>();
        }
    }
}
