using DiscountManagement.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShopManagement.Configuration;
namespace ServiceHost
{
    public class Startup
    {
       
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            //services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            //services.AddTransient<IProductApplication, ProductApplication>();
            //services.AddTransient<IProductRepository, ProductRepository>();

            //services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            //services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            //services.AddTransient<ISlideApplication, SlideApplication>();
            //services.AddTransient<ISlideRepository, SlideRepository>();

            //services.AddTransient<IOrderRepository, OrderRepository>();
            //services.AddTransient<IOrderApplication, OrderApplication>();

            //services.AddSingleton<ICartService, CartService>();




            //var connectionString = Configuration.GetConnectionString("BndShopDB");
            //services.AddTransient<IPermissionExposer, ShopPermissionExposer>();
            //services.AddDbContext<ShopContext>(x => x.UseSqlServer(connectionString));
            ShopManagementBootstrapper.Configure(services,Configuration.GetConnectionString("BndShopDB1"));
            DiscountManagementBootstrapper.Configure(services,Configuration.GetConnectionString("BndShopDB1"));
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
