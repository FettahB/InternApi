using FettahResearchProject.Application.ApiServices.Base.Request;
using FettahResearchProject.Application.ApiServices.Base.Response;
using FettahResearchProject.Application.ApiServices.Hotel.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Hotel.Services
{
    internal interface IHotelService
    {
        Task<GetByIdResponseBase<HotelObject>> GetByIdHotel(GetByIdRequestBase request);
    }
}
