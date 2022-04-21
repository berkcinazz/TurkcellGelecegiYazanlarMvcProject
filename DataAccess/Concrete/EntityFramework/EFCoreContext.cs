using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCoreContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=GYDatabase;Trusted_Connection=true");
        }
        public DbSet<User> Users{ get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims{ get; set; }
        public DbSet<OperationClaim> OperationClaims{ get; set; }
    }
}
