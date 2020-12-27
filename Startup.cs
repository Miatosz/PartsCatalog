using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using PartsCatalog.Models;
using PartsCatalog.Models.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

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
                opts.User.RequireUniqueEmail = true;
                //opts.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz";
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
            }).AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opts => opts.LoginPath = "/Account/Login");
                


            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddMemoryCache();
            services.AddSession();
        
            
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            
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
