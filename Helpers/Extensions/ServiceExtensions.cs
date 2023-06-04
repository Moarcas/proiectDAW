using proiectDAW.Helpers.Jwt;
using proiectDAW.Repositories.AnswerRepository;
using proiectDAW.Repositories.QuestionRepository;
using proiectDAW.Repositories.UserRepository;
using proiectDAW.Services.AnswerService;
using proiectDAW.Services.QuestionService;
using proiectDAW.Services.UserService;

namespace proiectDAW.Helpers.Extensions {
    public static class ServiceExtensions {
        public static IServiceCollection AddRepositories(this IServiceCollection services) {
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IQuestionRepository, QuestionRepository>();
            services.AddTransient<IAnswerRepository, AnswerRepository>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services) {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IQuestionService, QuestionService>();
            services.AddTransient<IAnswerService, AnswerService>();
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
