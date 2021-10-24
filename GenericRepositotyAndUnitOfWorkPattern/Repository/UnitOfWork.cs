using GenericRepositotyAndUnitOfWorkPattern.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDBContext _context;
        private readonly ILogger _logger;
        public UnitOfWork(ApplicationDBContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("Logs");
            Contact = new ContactRepository(context, _logger);
        }
        public IContactRepository Contact { get; private set; }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
