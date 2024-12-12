using Microsoft.Extensions.DependencyInjection;
using UserApplication.Service.Abstract;
using UserApplication.Service.Concrete;

namespace UserApplication.Service
{
    public static class ServiceRegistration
    {
        public static void AddService(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
        }
    }
}
