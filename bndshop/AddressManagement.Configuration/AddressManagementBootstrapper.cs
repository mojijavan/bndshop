

using AddressManagement.Application;
using AddressManagement.Application.Contracts.Address;
using AddressManagement.Application.Contracts.City;
using AddressManagement.Application.Contracts.Province;
using AddressManagement.Domain.AddressAgg;
using AddressManagement.Domain.CityAgg;
using AddressManagement.Domain.ProvineAgg;
using AddressManagement.Infrastructure.EFCore;
using AddressManagement.Infrastructure.EFCore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AddressManagement.Configuration
{
    public class AddressManagementBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
           

            services.AddTransient<IAddressApplication, AddressApplication>();
            services.AddTransient<ICityApplication, CityApplication>();
            services.AddTransient<IProvinceApplication, ProvinceApplication>();
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<ICityRepository, CityRepository>(); 
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddDbContext<AddressContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
