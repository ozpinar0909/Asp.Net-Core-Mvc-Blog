using Blog.Dal.Context;
using Blog.Dal.UnitOfWorks.Abstract;
using Blog.Dal.UnitOfWorks.Concrete;
using Blog.Entity.Abstract;
using Blog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Dal.Extensions
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            //Dependency Injection işlemlerini burada yapıyoruz.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddDbContext<BlogDbContext>(options => options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
