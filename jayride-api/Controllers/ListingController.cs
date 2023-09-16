using AutoMapper;
using DATA.Models;
using jayride_api.Models;
using LOGIC.Interface;
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
        public ListingController(IListingInterface listingInterface)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("jayride-api"));
            _mapper = new Mapper(configuration);
            _listingInterface = listingInterface;
        }
   
        [HttpGet()]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Models.Listing> Listings(double noOfPassengers)
        {
            var OrderednPricedListings = _mapper.Map<Models.Listing>(await _listingInterface.GetPricedListings(noOfPassengers));
            return OrderednPricedListings;
        }
    }
}
