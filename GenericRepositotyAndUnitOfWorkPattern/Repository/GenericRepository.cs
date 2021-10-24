using GenericRepositotyAndUnitOfWorkPattern.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDBContext _context;
        internal DbSet<T> dbSet;
        protected readonly ILogger _logger;
        public GenericRepository(ApplicationDBContext context, ILogger logger)
        {
            _context = context;
            dbSet = context.Set<T>();
            _logger = logger;
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual async void Dispose()
        {
            throw new NotImplementedException();
        }

        public virtual async Task<T> GetById(int id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
