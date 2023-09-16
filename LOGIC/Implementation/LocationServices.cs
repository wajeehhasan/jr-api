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
        private readonly IHttpOperations _httpOperations;
        private readonly ICommonInterface<Locations,LocationDTO> _commonInterface;
        private readonly IMapper _mapper;
        public LocationServices(ILocationOperations locationOperations, IHttpOperations httpOperations, ICommonInterface<Locations, LocationDTO> commonInterface)
        {
            _locationOperations = locationOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
            _httpOperations = httpOperations;
            _commonInterface = commonInterface;
        }

        public async Task<GenericResultSet<LocationDTO>> GetLocation(string ip_address)
        {
            GenericResultSet<LocationDTO> responseDTO = new();
            var ipDetails = await _locationOperations.GetIpDetailsAsync(ip_address);
            responseDTO = _commonInterface.convertResultSet<LocationDTO>(ipDetails, _mapper);
            return responseDTO;
        }
    }
}
