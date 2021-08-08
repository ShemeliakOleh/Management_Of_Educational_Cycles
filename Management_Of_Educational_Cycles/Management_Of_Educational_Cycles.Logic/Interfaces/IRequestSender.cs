using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Interfaces
{
    public interface IRequestSender
    {
        public Task<HttpResponseMessage> SendGetRequestAsync(string requestUri);
        public Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content);
        public Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content, string mediaType, Encoding encoding);
        public Task<T> GetContetFromRequestAsyncAs<T>(HttpResponseMessage response);
    }
}
