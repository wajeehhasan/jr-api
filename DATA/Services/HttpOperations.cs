using DATA.Interface;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace DATA.Services
{
    public class HttpOperations : IHttpOperations
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpOperations(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<string?> GetHttpResponse(string url, Dictionary<string, string> queryParams)
        {
            var builder = new UriBuilder(url);

            var query = HttpUtility.ParseQueryString(builder.Query);

            foreach (var item in queryParams)
            {
                query.Add(item.Key, item.Value);
            }

            builder.Query = query.ToString();
            var fullUrl = builder.ToString();

            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, fullUrl);


            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                return new StreamReader(contentStream).ReadToEnd();
            }
            return null;
        }
    }
}
