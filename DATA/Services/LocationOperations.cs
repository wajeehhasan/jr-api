using DATA.Interface;
using DATA.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Web;

namespace DATA.Services
{
    public class LocationOperations : ILocationOperations
    {
        private readonly IHttpOperations _httpOperations;
        private readonly IConfiguration _config;

        public LocationOperations(IConfiguration config, IHttpOperations httpOperations)
        {
            _config = config;
            _httpOperations = httpOperations;
        }
        public async Task<Location?> GetIpDetailsAsync(string ip_address)
        {
            var url = _config.GetSection("IpStackUrl").Value + ip_address;
            var queryParams = new Dictionary<string, string>(){
                {"access_key", _config.GetSection("IpstackAccessKey").Value}
            };

            return JsonConvert.DeserializeObject<Location>(await _httpOperations.GetHttpResponse(url, queryParams));
        }
    }
}
