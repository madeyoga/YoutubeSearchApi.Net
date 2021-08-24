using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    public interface IResponseResult
    {
        string Url { get; }
        string Title { get; }
        string Query { get; }
    }
}
