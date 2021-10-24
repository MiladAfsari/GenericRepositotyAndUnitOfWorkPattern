using GenericRepositotyAndUnitOfWorkPattern.Models;
using Repositoty.IRepositoty;
using Repositoty.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepository<T> _repository;
        public Service(IUnitOfWork unitOfWork, IRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public void Add(T entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public void Delete(T entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public IEnumerable<T> Get()
        {
            return _repository.Get();
        }

        public void Put(T entity)
        {
            _repository.Put(entity);
            _unitOfWork.Commit();
        }
    }
}
