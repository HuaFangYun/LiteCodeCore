using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace LiteCode.Core.Data
{
    /// <summary>
    /// 数据提供基类
    /// </summary>
    public class MainContext :DbContext, IMainContext
    {
        public MainContext(IConfigurationRoot configuration)
        {
            Configuration = configuration;
        }
        public MainContext(DbContextOptions<DbContext> options) :base(options)
        {
            
        }

        public DbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
        public IConfigurationRoot Configuration { get; }
    }
}
