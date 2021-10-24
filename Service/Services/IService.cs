using Repositoty.IRepositoty;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public interface IService<T>
    {
        IEnumerable<T> Get();
        void Add(T entity);
        void Put(T entity);
        void Delete(T entity);
    }
}
