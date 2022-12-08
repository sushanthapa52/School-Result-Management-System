using Microsoft.EntityFrameworkCore;
using SRMSDataAccess.Models;
using SRMSRepositories.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SRMSRepositories.Repositories
{
    public class Repository<T, T1> : IRepository<T,T1> where T : class
    {
     public readonly SrmsContext _sc;
        private DbSet<T> _dbSet;
        public Repository(SrmsContext sc)
        {
            _sc = sc;
            _dbSet = sc.Set<T>();

        }

        protected internal IQueryable<T> Table => _dbSet;

        protected internal IQueryable<T> TableAsNoTracking => _dbSet.AsNoTracking();

        public async Task DeleteAsync(T1 id)
        {
            var entity = await _dbSet.FindAsync(id);
            _dbSet.Remove(entity);
            Save();
        }


        public async Task DeleteAsync(T entity)
        {

            _dbSet.Remove(entity);
            Save();

        }

        public Task DeleteAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> FindBy(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        

        public Task<IQueryable<T>> FindByIdAsync(T1 id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            Save();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            Save();
        }

        public Task UpdateAsync(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }
        protected void Save()
        {
            _sc.SaveChanges();
        }
    }
}
