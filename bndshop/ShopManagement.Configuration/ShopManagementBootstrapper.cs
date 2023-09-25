using _0_Framework.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.Product;

using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.Domain.SlideAgg;

using ShopManagement.Infrastructure.EFCore;
using ShopManagement.Infrastructure.EFCore.Repository;


namespace ShopManagement.Configuration
{
    public class ShopManagementBootstrapper : IDesignTimeDbContextFactory<ShopContext>
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IOrderApplication, OrderApplication>();

            //services.AddSingleton<ICartService, CartService>();

          

            

            services.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
        }

        public ShopContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ShopContext>();

            optionsBuilder.UseSqlServer("your connection string");

            return new ShopContext(optionsBuilder.Options);
        }
    }
}