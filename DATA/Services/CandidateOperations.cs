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
        public GenericResultSet<CandidateData> GetCandidate()
        {

            GenericResultSet<CandidateData> response = new();
            response.resultSet = new CandidateData { name = "test", phone = "test" };
            //this is returning sample data and can be replaced by a database call
            return response; 
        }
    }
}
