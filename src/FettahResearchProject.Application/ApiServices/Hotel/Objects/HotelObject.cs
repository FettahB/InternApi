using FettahResearchProject.Application.ApiServices.Base.Object;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Hotel.Objects
{
    public class HotelObject: BaseObject
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }

        public string? BrandName { get; set; }

        public int? RoomCount { get; set; }
    }
}
