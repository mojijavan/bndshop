

using AddressManagement.Domain.AddressAgg;
using AddressManagement.Domain.CityAgg;
using AddressManagement.Domain.ProvineAgg;
using AddressManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AddressManagement.Infrastructure.EFCore
{
    public class AddressContext:DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public AddressContext(DbContextOptions<AddressContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(AddressMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
