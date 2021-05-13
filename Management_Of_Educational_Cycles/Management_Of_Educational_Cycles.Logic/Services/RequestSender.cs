using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Management_Of_Educational_Cycles.Logic.Services
{
    public class RequestSender : IRequestSender
    {
        private HttpClient _client;
        public RequestSender()
        {
            _client = new HttpClient();
        }
        public async Task<HttpResponseMessage> SendGetRequestAsync(string requestUri)
        {
            return await _client.GetAsync(requestUri);
        }

        public async Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content)
        {
            var json = JsonConvert.SerializeObject(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            return await _client.PostAsync(requestUri, data);
        }

        public async Task<HttpResponseMessage> SendPostRequestAsync(string requestUri, object content, string mediaType, Encoding encoding)
        {
            var json = JsonConvert.SerializeObject(content);
            var data = new StringContent(json, encoding, mediaType);
            return await _client.PostAsync(requestUri, data);
        }
    }
}
