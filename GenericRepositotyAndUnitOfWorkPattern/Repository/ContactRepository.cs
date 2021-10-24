using GenericRepositotyAndUnitOfWorkPattern.Data;
using GenericRepositotyAndUnitOfWorkPattern.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Repository
{
    public class ContactRepository : GenericRepository<Contact>, IContactRepository
    {
        public ContactRepository(ApplicationDBContext context, ILogger logger) : base(context, logger)
        {

        }
        public override async Task<IEnumerable<Contact>> All()
        {
            try
            {
                return await dbSet.ToListAsync();

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{REP} All Func Error", typeof(ContactRepository));
                return new List<Contact>();
            }
        }
        public override async Task<bool> Upsert(Contact entity)
        {
            try
            {
                var existingUser = await dbSet.Where(x => x.Id == entity.Id).FirstOrDefaultAsync();
                if (existingUser == null)
                {
                    return await Add(entity);
                }
                existingUser.Email = entity.Email;
                existingUser.Family = entity.Family;
                existingUser.Name = entity.Name;
                existingUser.Phone = entity.Phone;
                existingUser.RegisterDate = entity.RegisterDate;
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{REP} Upsert Func Error", typeof(ContactRepository));
                return false;
            }
        }
        public override async Task<bool> Delete(int id)
        {
            try
            {
                var exist = await dbSet.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (exist == null)
                {
                    return false;
                }
                dbSet.Remove(exist);
                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "{REP} Delete Func Error", typeof(ContactRepository));
                return false;
            }
        }
    }
}
