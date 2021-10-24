using Repositoty.IRepositoty;
using Repositoty.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoty.Repositoty
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private readonly IUnitOfWork _unitOfWork;
        public Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            _unitOfWork.Context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            T exist = _unitOfWork.Context.Set<T>().Find(entity);
            if (exist != null)
            {
                _unitOfWork.Context.Set<T>().Remove(exist);
            }
        }

        public IEnumerable<T> Get()
        {
            return _unitOfWork.Context.Set<T>();
        }

        public void Put(T entity)
        {
            _unitOfWork.Context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _unitOfWork.Context.Set<T>().Attach(entity);
        }
    }
}
