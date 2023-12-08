using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FettahResearchProject.Infrastructure.Repositories
{
    public interface IBaseRepository<T>
    {
        Task<T?> GetById(int id);

        IQueryable<T> Table();

        IQueryable<T> TableWithDeleted();

        IQueryable<T> TableWithCondition(Expression<Func<T, bool>> expression);

        void Update(T entity, int? updatedBy);

        void SoftDelete(T entity, int? updatedBy);

        void PermanentDelete (T entity);



    }
}
