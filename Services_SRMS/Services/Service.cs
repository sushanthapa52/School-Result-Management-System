using SRMSRepositories.IRepositories;
using SRMSServices.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRMSServices.Services
{
    public class Service<T, T1> : IService<T, T1> where T : class
    {
        private readonly IRepository<T, T1> _repository;

        public Service(IRepository<T,T1> repository)
        {
            this._repository = repository;
        }
        public async Task DeleteAsync(T1 id)
        {
           await _repository.DeleteAsync(id);
        }

        public async Task DeleteAsync(T entity)
        {
            await _repository.DeleteAsync(entity);
        }

      

        public Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> FindByIdAsync(T1 id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
         return   await _repository.GetAllAsync();
        }

        public Task SaveAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }
    }
}
