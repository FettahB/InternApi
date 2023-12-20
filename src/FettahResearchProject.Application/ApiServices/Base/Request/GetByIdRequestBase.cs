using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Base.Request
{
    public class GetByIdRequestBase :RequestBase
    {
        public int Id { get; set; }
    }
}
