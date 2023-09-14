using AutoMapper;
using DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LOGIC.Model
{

    [AutoMap(typeof(Location))]
    public class LocationDTO
    {
        public string city { get; set; }
    }
}
