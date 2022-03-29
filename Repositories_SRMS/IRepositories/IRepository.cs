using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.IRepositories
{
    public interface IRepository<T, T1> where T : class
    {
        Task SaveAsync(T entity);
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> condition);
        Task<IQueryable<T>> FindByIdAsync(T1 id);
        Task UpdateAsync(T entity);
        Task UpdateAsync(Expression<Func<T, bool>> condition);

        Task DeleteAsync(T1 id);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Expression<Func<T, bool>> condition);
        IQueryable<T> Table { get; }
        IQueryable<T> TableAsNoTracking { get; }


    }
}
