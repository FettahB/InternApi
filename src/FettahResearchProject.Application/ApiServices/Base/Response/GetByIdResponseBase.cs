using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Base.Response
{
    public class GetByIdResponseBase<T> : ResponseBase
    {
        public T Data { get; set; }
    }
}
