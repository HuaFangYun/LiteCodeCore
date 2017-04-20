using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LiteCode.IService;
using Lucky.IService.News;
using Lucky.Service;
using Lucky.Service.News;
using LuckyCode.Core.Service;
using Microsoft.Extensions.DependencyInjection;

namespace LiteCode.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            services.AddScoped<ISignal, Signal>();
            services.AddScoped<ISysUserService, SysUserService>();
            services.AddScoped<ISysModulesService, SysModulesService>();
            services.AddScoped<ISysApplicationService, SysApplicationService>();
            services.AddScoped<ISysDepartmentService, SysDepartmentService>();
            services.AddScoped<ISysRolesService, SysRolesService>();
            services.AddScoped<ILinkService, LinkService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<INewsArticleService, NewsArticleService>();
            services.AddScoped<INewsBannerService, NewsBannerService>();
            return services;
        }
    }
}
