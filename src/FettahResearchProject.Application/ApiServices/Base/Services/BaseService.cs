using FettahResearchProject.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Application.ApiServices.Base.Services
{
    public abstract class BaseService :IBaseService
    {
        private readonly IUnitOfWork _uow;

        public BaseService(IUnitOfWork uow)
        {
            _uow = uow; 
        }
    }
}
