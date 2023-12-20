using FettahResearchProject.Infrastructure.Data;
using FettahResearchProject.Infrastructure.Repositories;
using FettahResearchProject.Models.Entities;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Infrastructure.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly MyDbContext _dbContext;
        private bool _disposed;

        private readonly Lazy<IBaseRepository<Hotel>> _hotelRepository;

        private static Lazy<IBaseRepository<TEntity>> CreateRepository<TEntity>(MyDbContext dbContext) where TEntity : BaseEntity
        {
            return new Lazy<IBaseRepository<TEntity>>(() => new BaseRepository<TEntity>(dbContext));
        }

        public UnitOfWork(MyDbContext dbContext, ILogger<UnitOfWork> logger)
        {
            _dbContext = dbContext;
            _hotelRepository = CreateRepository<Hotel>(dbContext);
        }

        public async Task Commit()
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    await _dbContext.SaveChangesAsync();
                    //There should be an foreignkey control
                    _dbContext.DetachAll();

                    await transaction.CommitAsync();
                }
                catch (Exception e)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            this._disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task TransactionCommit(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _dbContext.Database.BeginTransactionAsync();
        }

        public async Task TransactionRollback(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync(bool isDelete = false)
        {
            return await _dbContext.SaveChangesAsync();
        }

        public int SaveChanges()
        {
            int save = _dbContext.SaveChanges();
            return save;
        }

        public IBaseRepository<Hotel> Hotel=> _hotelRepository.Value;

    }
}
