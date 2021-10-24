using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoty.IRepositoty
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> Get();
        void Add(T entity);
        void Put(T entity);
        void Delete(T entity);

    }
}
