using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MobileStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileStore.Repository
{
    public class MobileDbContext : DbContext
    {
        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Visual> Visuals { get; set; }

        public MobileDbContext(DbContextOptions<MobileDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
