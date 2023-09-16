using LOGIC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Interface
{
    public interface IListingInterface
    {
        Task<ListingDTO> GetPricedListings(double noOfPassengers);
    }
}
