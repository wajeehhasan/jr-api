using AutoMapper;
using DATA.Interface;
using LOGIC.Interface;
using LOGIC.Model;

namespace LOGIC.Implementation
{
    public class CandidateService : ICandidate
    {
        //calling data layer candidate services
        readonly ICandidateOperations _candidateOperations;
        //creating an instance of AutoMapper to Map Data Layer Cadidate to Logic Layer Candidate Model
        private readonly IMapper _mapper;

        //making use of dependency injections so that we have access to automapper and datalayer operations in our class
        public CandidateService(ICandidateOperations candidateOperations)
        {
            _candidateOperations = candidateOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
        }

        public CandidateDTO GetCandidate()
        {
            //calling data layer operations to return desired result while also mapping it to the correct model.
            CandidateDTO candidate = _mapper.Map<CandidateDTO>(_candidateOperations.GetCandidate());
            return candidate;
        }
    }
}
