using GenericRepositotyAndUnitOfWorkPattern.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenericRepositotyAndUnitOfWorkPattern.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Contact>().HasData(

        //        new Contact { Id = 3, Name = "Mili", Family = "AF", Email = "M@gmail.com", Phone = "09137864660" },
        //        new Contact { Id = 4, Name = "AK", Family = "AF", Email = "A@gmail.com", Phone = "09103005218" },
        //        new Contact { Id = 5, Name = "AK", Family = "AF", Email = "A@gmail.com", Phone = "09103005218" });
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(
            //    @"Server=(localdb)\mssqllocaldb;Database=EFQuerying.Tracking;Trusted_Connection=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
