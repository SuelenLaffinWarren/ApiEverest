using DomainModels.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiEverest.Context
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) 
            : base(options) => Database.EnsureCreated();
        
        public DbSet<CustomerEntity> CustomerEntity { get; set; }  
    }
}
