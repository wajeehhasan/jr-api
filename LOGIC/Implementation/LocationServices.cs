using LOGIC.Model;
using LOGIC.Interface;
using DATA.Models;
using DATA.Interface;
using AutoMapper;
using DATA.Services;

namespace LOGIC.Implementation
{
    public class LocationServices : ILocationInterface
    {
        private readonly ILocationOperations _locationOperations;
        private readonly IMapper _mapper;
        public LocationServices(ILocationOperations locationOperations)
        {
            _locationOperations = locationOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
        }

        public async Task<LocationDTO> GetLocation(string ip_address)
        {
            var x = await _locationOperations.GetIpDetailsAsync(ip_address);
            LocationDTO location = _mapper.Map<LocationDTO>(x);
            return location;
        }
    }
}
