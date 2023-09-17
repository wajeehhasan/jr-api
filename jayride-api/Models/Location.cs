using AutoMapper;
using LOGIC.Model;

namespace jayride_api.Models
{
    [AutoMap(typeof(LocationLOGIC))]
    public class Location
    {
        public string city { get; set; }
    }
}
