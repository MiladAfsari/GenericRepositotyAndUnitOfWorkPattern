using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositoty.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public DbContext Context { get; }
        void Commit();
    }
}
