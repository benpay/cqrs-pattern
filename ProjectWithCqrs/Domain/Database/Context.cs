using CoreProject.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Domain.Database
{
    public class Context : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AddressesHistoryModel> Addresses { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite(@"Data source=C:\\temp\\ProjectWithCqrsDatabase.db");

        public async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
