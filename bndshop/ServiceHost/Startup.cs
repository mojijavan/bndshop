using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using _0_Framework.Application;
using _0_Framework.Application.Email;
using _0_Framework.Application.Sms;
using _0_Framework.Application.ZarinPal;
using _0_Framework.Infrastructure;
using AccountManagement.Configuration;
using AddressManagement.Configuration;
using BlogManagement.Infrastructure.Configuration;
using CommentManagement.Infrastructure.Configuration;
using DiscountManagement.Configuration;
using InventoryManagement.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel.Core;
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
            services.AddHttpContextAccessor();
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Arabic));
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IFileUploader, FileUploader>();
            services.AddTransient<IAuthHelper, AuthHelper>();
            services.AddTransient<IZarinPalFactory, ZarinPalFactory>();
            services.AddTransient<ISmsService, SmsService>();
            services.AddTransient<IEmailService, EmailService>();
            //var connectionString = Configuration.GetConnectionString("BndShopDB1");
            //var connectionString = Configuration.GetConnectionString("LocalDB");
            
            var connectionString = Configuration.GetConnectionString("RemoteShopDB");
            AddressManagementBootstrapper.Configure(services, connectionString);
            ShopManagementBootstrapper.Configure(services, connectionString);
            DiscountManagementBootstrapper.Configure(services, connectionString);
            InventoryManagementBootstrapper.Configure(services, connectionString);
            BlogManagementBootstrapper.Configure(services, connectionString);
            CommentManagementBootstrapper.Configure(services, connectionString);
            AccountManagementBootstrapper.Configure(services, connectionString);
            



            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Lax;
            });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
                {
                    o.LoginPath = new PathString("/Account");
                    o.LogoutPath = new PathString("/Account");
                    o.AccessDeniedPath = new PathString("/AccessDenied");
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminArea",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));
                options.AddPolicy("CustomerPolicy",
                   builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader,Roles.SystemUser,Roles.ColleagueUser }));

                options.AddPolicy("Shop",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator, Roles.ContentUploader }));

                options.AddPolicy("Discount",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator }));

                options.AddPolicy("Account",
                    builder => builder.RequireRole(new List<string> { Roles.Administrator }));
            });

            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            // If using IIS:
            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            //services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
                builder
                    .WithOrigins("https://localhost:5002")
                    .AllowAnyHeader()
                    .AllowAnyMethod()));
            services.AddRazorPages()
                .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AuthorizeAreaFolder("Administration", "/", "AdminArea");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Shop", "Shop");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Discounts", "Discount");
                    options.Conventions.AuthorizeAreaFolder("Administration", "/Accounts", "Account");
                    options.Conventions.AuthorizeAreaFolder("Customer", "/", "CustomerPolicy");
                    //Customer
                })
                //.AddApplicationPart(typeof(ProductController).Assembly)
                //.AddApplicationPart(typeof(InventoryController).Assembly)
                .AddNewtonsoftJson();
            //services.AddControllers().AddNewtonsoftJson();
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

            app.UseAuthentication();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCookiePolicy();

            app.UseRouting();
           
            app.UseAuthorization();

            app.UseCors("MyPolicy");
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name:"ProductCategory",
            //        template:"ProductCategory/{parentSlug}/{slug?}/{label?}"
            //    );
            //});

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }
    }
}
