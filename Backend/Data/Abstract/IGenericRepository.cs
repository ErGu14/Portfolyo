using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = ""
            );
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string includeProperties = "");
        Task<int> CountAsync(Expression<Func<T, bool>>? filter = null);
        Task<T>? GetByIdAsync(object id);

        Task AddAsync(T entity);
        void UpdateAsync(T entity);
        void Delete(int id);
        Task SaveAsync();
    }
}
