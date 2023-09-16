﻿
using DATA.Models;

namespace DATA.Interface
{
    public interface IListingOperations
    {
        Task<GenericResultSet<Listing>> GetAllListings();
    }
}
