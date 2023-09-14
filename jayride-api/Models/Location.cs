using AutoMapper;
using LOGIC.Model;

namespace jayride_api.Models
{
    [AutoMap(typeof(LocationDTO))]
    public class Location
    {
        public string city { get; set; }
    }
}
