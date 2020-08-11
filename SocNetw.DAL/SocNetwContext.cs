using Microsoft.EntityFrameworkCore;
using SocNetw.DAL.Models;
using System;

namespace SocNetw.DAL
{
    public class SocNetwContext : DbContext
    {
        public SocNetwContext(DbContextOptions<SocNetwContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<Credentials> Credentials { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
