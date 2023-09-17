using AutoMapper;
using DATA.Models;
using jayride_api.Models;
using LOGIC.Interface;
using LOGIC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mime;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jayride_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListingController : ControllerBase
    {
        private readonly Mapper _mapper;
        private readonly IListingInterface _listingInterface;
        private readonly ICommonInterface<ListingsLOGIC, Listing> _commonInterface;
        public ListingController(IListingInterface listingInterface, ICommonInterface<ListingsLOGIC, Listing> commonInterface)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("jayride-api"));
            _mapper = new Mapper(configuration);
            _listingInterface = listingInterface;
            _commonInterface = commonInterface;
        }

        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<GenericResultSet<Listing>> Listings(double noOfPassengers)
        {
            GenericResultSet<Listing> response = new();
            var returnedOBj = await _listingInterface.GetPricedListings(noOfPassengers);
            response = _commonInterface.convertResultSet<Listing>(returnedOBj, _mapper);
            return response;
        }
    }
}
