using Microsoft.EntityFrameworkCore;
using SocNetw.DAL.Models;
using System;

namespace SocNetw.DAL
{
    public class SocNetwContext : DbContext
    {
        public SocNetwContext(DbContextOptions<SocNetwContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<AccountEntity> AccountEntities { get; set; }

        public DbSet<CredentialsEntity> CredentialsEntities { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
