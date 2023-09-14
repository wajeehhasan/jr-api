using AutoMapper.Configuration.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Interface
{
    public interface IHttpOperations
    {
        Task<string?> GetHttpResponse(string url, Dictionary<string, string> queryParams);
    }
}
