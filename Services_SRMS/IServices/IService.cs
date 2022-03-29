using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.IServices
{
  public interface IService<T,T1> where T:class
    {
        Task SaveAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindByIdAsync(T1 id);
        Task UpdateAsync(T entity);
    
        Task DeleteAsync(T1 id);
        Task DeleteAsync(T entity);
       

    }
}
