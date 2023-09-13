using AutoMapper;
using LOGIC.Model;

namespace jayride_api.Models
{
    [AutoMap(typeof(CandidateDTO))]
    public class Candidate
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
