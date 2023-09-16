using AutoMapper;
using DATA.Interface;
using LOGIC.Interface;
using LOGIC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Implementation
{
    public class ListingService : IListingInterface
    {
        private readonly IListingOperations _listingOperations;
        private readonly IMapper _mapper;
        public ListingService(IListingOperations listingOperations)
        {
            _listingOperations = listingOperations;
            var configuration = new MapperConfiguration(cfg => cfg.AddMaps("LOGIC"));
            _mapper = new Mapper(configuration);
        }
        public async Task<ListingDTO> GetPricedListings(double noOfPassengers)
        {
            //get all listings from API
            var allListings = await _listingOperations.GetAllListings();


            //filtering listingdetails where no of passengers are greater
            allListings.resultSet.listings = allListings.resultSet.listings.Where(item => item.vehicleType.maxPassengers>=noOfPassengers).ToList();


            //maping to logic layer listing model with added property of "totalPrice" so that it can be ordered.
            ListingDTO pricedListing = _mapper.Map<ListingDTO>(allListings);


            pricedListing.listings = pricedListing.listings
                .Select(item => { item.totalPrice = item.pricePerPassenger * noOfPassengers; return item; }) //calculating total price
                .OrderBy(item=> item.totalPrice) //ordering by totalPrice
                .ToList();

            return pricedListing;
        }
    }
}
