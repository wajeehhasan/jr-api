using AutoMapper;
using jayride_api.Models;
using LOGIC.Interface;
using LOGIC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace jayride_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly Mapper _mapper;
        private readonly ILocationInterface _location;
        public LocationController(ILocationInterface location)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("jayride-api"));
            _mapper = new Mapper(configuration);
            _location = location;
        }

        [HttpGet]
        public async Task<Location> Location(string ip_address)
        {
            Location location = _mapper.Map<Location>(await _location.GetLocation(ip_address));
            return location;
        }
    }
}
