﻿using DATA.Interface;
using DATA.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;


namespace DATA.Services
{
    public class ListingOperations : IListingOperations
    {
        private readonly IHttpOperations _httpOperations;
        private readonly IConfiguration _config;
      
        public ListingOperations(IHttpOperations httpOperations, IConfiguration config)
        {
            _httpOperations = httpOperations;
            _config = config;
    
        }
        public async Task<GenericResultSet<Listing>> GetAllListings()
        {
            GenericResultSet<Listing> response = new();
            var url = _config.GetSection("JayrideChallengeApi").Value;
            var returnedObject = await _httpOperations.GetHttpResponse(url);
            response = _httpOperations.GenericResponseGenerate<Listing>(returnedObject);
            return response;
        }
    }
}