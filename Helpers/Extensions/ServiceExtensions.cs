
using proiectDAW.Helpers.Jwt;
using proiectDAW.Repositories.UserRepository;
using proiectDAW.Services.UserService;

namespace proiectDAW.Helpers.Extensions {
    public static class ServiceExtensions {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddTransient<IUserService, UserService>();
            return services;  
        }

        // public static IServiceCollection AddSeeders(this IServiceCollection services) {
        //     return services;
        // }

        public static IServiceCollection AddUtils(this IServiceCollection services) {
            services.AddTransient<IJwtUtils, JwtUtils>();
            return services;
        }
    }
}