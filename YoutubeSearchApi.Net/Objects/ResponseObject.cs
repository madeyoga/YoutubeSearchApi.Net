using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    class ResponseObject
    {
        public string Url { get; set; }
        public string Query { get; set; }
        public ICollection<IResponseResult> Results { get; }

        public ResponseObject()
        {
            Results = new List<IResponseResult>();
        }
    }
}
