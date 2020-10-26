using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeSearchApi.Net.Exceptions
{
    [Serializable()]
    public class NoResultFoundException : System.Exception
    {
        public NoResultFoundException() : base() { }
        public NoResultFoundException(string message) : base(message) { }
        public NoResultFoundException(string message, System.Exception inner) : base(message, inner) { }

        // A constructor is needed for serialization when an
        // exception propagates from a remoting server to the client.
        protected NoResultFoundException(System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
