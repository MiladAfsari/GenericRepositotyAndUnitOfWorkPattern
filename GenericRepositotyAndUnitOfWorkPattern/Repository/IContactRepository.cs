using GenericRepositotyAndUnitOfWorkPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Repository
{
    public interface IContactRepository : IGenericRepository<Contact>
    {
    }
}
