using AutoMapper;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interface
{
    public interface ICommonInterface<SourceResultSet, DestinationResultSet>
    {
        GenericResultSet<DestinationResultSet> convertResultSet<DestinationResultSet>(GenericResultSet<SourceResultSet> resultSet, IMapper _mapper);
    }
}
