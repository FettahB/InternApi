using FettahResearchProject.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task Commit();

        int SaveChanges();

        IBaseReposity<Hotel> Hotel { get; }
    }
}
