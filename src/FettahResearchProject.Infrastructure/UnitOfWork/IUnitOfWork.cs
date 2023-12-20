using FettahResearchProject.Infrastructure.Repositories;
using FettahResearchProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;
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

        Task<IDbContextTransaction> BeginTransactionAsync();

        Task TransanctionCommit(IDbContextTransaction transaction);
        Task TransactionRollback(IDbContextTransaction transaction);

        Task<int> SaveChangesAsync(bool isDelete = false);

        IBaseRepository<Hotel> Hotel {  get; }
    }
}
