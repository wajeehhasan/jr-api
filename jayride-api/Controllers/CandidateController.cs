using AutoMapper;
using DATA.Services;
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
        
        private readonly IMapper _mapper;
        public CandidateController(ICandidateInterface candidateService)
        {
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("jayride-api"));
            _mapper = new Mapper(configuration);
            _candidateService = candidateService;
        }

        // GET: api/<CandidateController>
        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public Candidate candidate()
        {
            Candidate candidate = _mapper.Map<Candidate>(_candidateService.GetCandidate());
            return candidate;
           
        }
    }
}
