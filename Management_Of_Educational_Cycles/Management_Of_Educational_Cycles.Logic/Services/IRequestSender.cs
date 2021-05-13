using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
    public interface IRequestSender
    {
        public Task<HttpResponseMessage> SendGetRequestAsync(string requestUri);
        public Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content);
        public Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content, string mediaType, Encoding encoding);
    }
}
