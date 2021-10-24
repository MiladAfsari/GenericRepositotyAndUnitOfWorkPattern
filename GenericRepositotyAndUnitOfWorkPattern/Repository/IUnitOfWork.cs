using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository Contact { get; }
        Task CompleteAsync();
    }
}
