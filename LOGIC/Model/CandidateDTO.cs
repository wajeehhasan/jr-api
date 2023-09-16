using AutoMapper;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Model
{
    [AutoMap(typeof(Candidates))]
    public class CandidateDTO
    {
        public string name { get; set; }
        public string phone { get; set; }
    }
}
