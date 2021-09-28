using FrontEk7.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace FrontEk7.Repository
{
    public class EFContexto : DbContext
    {
        public virtual DbSet<SecurityAccess> SecurityAccess { get; set; }
        public EFContexto(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Assembly assemblyWithConfigurations = GetType().Assembly; //get whatever assembly you want
            //modelBuilder.ApplyConfigurationsFromAssembly(assemblyWithConfigurations);
        }
    }
}
