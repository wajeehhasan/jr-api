using AutoMapper;
using DATA.Models;
using jayride_api.Models;
using LOGIC.Interface;
using LOGIC.Model;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace jayride_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ICandidateInterface _candidateService;

        private readonly ICommonInterface<CandidateLOGIC, Candidate> _commonInterface;
        private readonly IMapper _mapper;
        public CandidateController(ICandidateInterface candidateService, ICommonInterface<CandidateLOGIC, Candidate> commonInterface)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("jayride-api"));
            _mapper = new Mapper(configuration);
            _candidateService = candidateService;
            _commonInterface = commonInterface;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public GenericResultSet<Candidate> candidate()
        {
            GenericResultSet<Candidate> response = new();
            var returnedObj = _candidateService.GetCandidate();
            response = _commonInterface.convertResultSet<Candidate>(returnedObj, _mapper);
            return response;
           
        }
    }
}
