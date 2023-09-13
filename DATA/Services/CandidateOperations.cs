using DATA.Interface;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA.Services
{
    public class CandidateOperations : ICandidateOperations
    {
        public Candidate GetCandidate()
        {
            //this is returning sample data and can be replaced by a database call
            return new Candidate { name = "test", phone = "test" }; 
        }
    }
}
