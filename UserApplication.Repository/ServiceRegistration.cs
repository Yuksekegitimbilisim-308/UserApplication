using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UserApplication.Repository.Repositories;

namespace UserApplication.Repository
{
    public static class ServiceRegistration
    {
        //Extension
        public static void AddRepository(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(conf =>
            {
                conf.UseSqlServer(configuration.GetConnectionString("mssql"));
            });
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
