using AutoMapper;
using LOGIC.Model;

namespace jayride_api.Models
{
    [AutoMap(typeof(CandidateLOGIC))]
    public class Candidate
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
