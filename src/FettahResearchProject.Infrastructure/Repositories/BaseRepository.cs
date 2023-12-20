using FettahResearchProject.Enums;
using FettahResearchProject.Infrastructure.Data;
using FettahResearchProject.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly MyDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public async Task<T?> GetById(int id)
        {
            return await _dbSet.Where(x => x.Id == id && x.Status != Status.Deleted).AsNoTracking().FirstOrDefaultAsync();
        }

        public IQueryable<T> Table()
        {
            return _dbSet.Where(e => e.Status != Status.Deleted).AsNoTracking();
        }

        public IQueryable<T> TableWithCondition(Expression<Func<T,bool>> expression)
        {
            return _dbSet.Where(e => e.Status != Status.Deleted).Where(expression).AsNoTracking();
        }

        public IQueryable<T> TableWithDeleted()
        {
            return _dbSet;  
        }

        public void Update(T entity, int? updatedBy) { 
            var old = GetById(entity.Id).Result;
            if(old != null)
            {
                entity.CreatedBy = old.CreatedBy;
                entity.CreatedAt = old.CreatedAt.ToUniversalTime();
            }
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public void SoftDelete(T entity, int? updatedBy)
        {
            entity.Status = Status.Deleted;
            entity.UpdatedBy = updatedBy;
            entity.UpdatedAt = DateTime.UtcNow;
            _dbSet.Update(entity);
        }

        public void PermanentDelete(T entity)
        {
            _dbSet.Remove(entity);
        }

    }
}
