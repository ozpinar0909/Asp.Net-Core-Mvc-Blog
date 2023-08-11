using Blog.Entity.Abstract;
using Blog.Entity.Concrete;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Dal.Extensions
{
    public static class DataAccessLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            //Dependency Injection işlemlerini burada yapıyoruz.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            return services;
        }
    }
}
