using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.Core.Data;
using LiteCode.Core.Filtes;
using LiteCode.Data;
using LiteCode.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using LiteCode.Service;
using Microsoft.EntityFrameworkCore;

namespace LuckyCode.WebSite
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LiteCodeContext>(options =>
                   options.UseMySql(Configuration.GetConnectionString("mySqlConnection")));

            services.AddScoped(typeof(IRepository<>), typeof(EntityRepository<>));
            services.AddIdentity<SysUsers, SysRoles>()
                .AddEntityFrameworkStores<LiteCodeContext, string>()
                .AddDefaultTokenProviders();
            // Add framework services.
            services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = 1024 * 1024 * 100; //100M上传
            });
            services.Configure<IdentityOptions>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequiredLength = 6;
            });
            // services.AddScoped<ILiteCodeContext>(x => new LiteCodeContext(new DbContextOptionsBuilder<LiteCodeContext>().UseSqlServer(Configuration.GetConnectionString("mySqlConnection")).Options));
            services.AddScoped<ILiteCodeContext>(x => x.GetService<LiteCodeContext>());
            services.AddScoped<IMainContext>(x => x.GetService<ILiteCodeContext>());


           // services.AddScoped<IDatabase>(x => new Database(Configuration.GetConnectionString("mySqlConnection"), DatabaseType.MySQL, Pomelo.Data.MySql.MySqlClientFactory.Instance));

            services.AddAuthorization(options =>
            {
                options.AddPolicy(Policies.CanViewUsers,
                    policy => policy.Requirements.Add(new ResourceRequirement()));
            });

            services.AddSingleton<IAuthorizationHandler, ResourceHandler>();



            services.AddService();
           

            services.AddMvc().AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            List<string> a=new List<string>();
            var c=a.Select(b => Convert.ToInt32(b)).ToList();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
