using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PartsCatalog.Models;
using PartsCatalog.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection.Extensions;
using PartsCatalog.Data;

namespace PartsCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;


        public IConfiguration Configuration { get; set;}


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration["Data:PartsCatalog:ApplicationConnectionString"]));    

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(Configuration["Data:PartsCatalog:AppIdentityConnectionString"]));       

            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlite("Data Source=baza.db"));      

            // services.AddDbContext<AppIdentityDbContext>(options =>
            //     options.UseSqlite("Data Source=Identity.db")); 

            services.AddIdentity<AppUser, IdentityRole>(opts => 
            {
                opts.SignIn.RequireConfirmedEmail = false;
                opts.User.RequireUniqueEmail = false;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");
                
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            
            services.AddMemoryCache();
            services.AddSession();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });

            services.AddMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });


            // services.AddMailKit(config => 
            //     config.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>()));
            
            services.AddMailKit(optionBuilder =>
            {
                optionBuilder.UseMailKit(new MailKitOptions()
                {
                    Server = Configuration["Email:Server"],
                    Port = Convert.ToInt32(Configuration["Email:Port"]),
                    SenderName = Configuration["Email:SenderName"],
                    SenderEmail = Configuration["Email:SenderEmail"],
                    Account = Configuration["Email:Account"],
                    Password = Configuration["Email:Password"],
                    Security = true
                });
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });
            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}"                    
                );

                routes.MapRoute(
                    name: null,
                    template: "{controller}",
                    defaults: new {action="ListProducts"}
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new {controller="User",Action="ListProducts"}
                );

                routes.MapRoute(
                    name: null,
                    template: "{controller}/{action}/{id?}"
                );
            });

            // SaveContext.EnsurePopulated(app);
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            AppIdentityDbContext.CreateAdminAccount(app.ApplicationServices, Configuration).Wait();

            context.Database.Migrate();
            IdentitySeedData.EnsurePopulated(app);
        }
        
    }
}
