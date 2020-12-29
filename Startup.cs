using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PartsCatalog.Models;
using PartsCatalog.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using NETCore.MailKit.Extensions;
using NETCore.MailKit.Infrastructure.Internal;
using System;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace PartsCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;


        public IConfiguration Configuration { get; set;}


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            // services.AddDbContext<ApplicationDbContext>(options =>
            //     options.UseSqlServer(Configuration["Data:PartsCatalog:ConnectionString"]));         

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite("Data Source=baza.db"));      

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlite("Data Source=Identity.db")); 

            services.AddIdentity<AppUser, IdentityRole>(opts => 
            {
                opts.SignIn.RequireConfirmedEmail = true;
                opts.User.RequireUniqueEmail = true;
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

            
            services.AddMemoryCache();
            services.AddSession();

            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.KnownProxies.Add(IPAddress.Parse("10.0.0.100"));
            });

            services.AddMemoryCache();
            services.AddSession();
            


            // services.AddMailKit(config => 
            //     config.UseMailKit(Configuration.GetSection("Email").Get<MailKitOptions>()));
            
            services.AddMailKit(optionBuilder =>
    {
        optionBuilder.UseMailKit(new MailKitOptions()
        {
            //get options from sercets.json
            Server = Configuration["Email:Server"],
            Port = Convert.ToInt32(Configuration["Email:Port"]),
            SenderName = Configuration["Email:SenderName"],
            SenderEmail = Configuration["Email:SenderEmail"],
			
            // can be optional with no authentication 
            Account = Configuration["Email:Account"],
            Password = Configuration["Email:Password"],
            // enable ssl or tls
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
            context.Database.Migrate();
            //IdentitySeedData.EnsurePopulated(app);
        }
        
    }
}
