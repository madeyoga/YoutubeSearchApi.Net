using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Objects
{
    public interface IResponseObject
    {
        string Url { get; }
        List<object> Results { get; }
    }
}
