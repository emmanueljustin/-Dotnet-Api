using BaseApi.Repository.GoalRepository;
using BaseApi.Repository.PostRepository;
using BaseApi.Repository.UserRepository;
using BaseApi.Services.GoalService;
using BaseApi.Services.PostService;
using BaseApi.Services.UserService;

namespace BaseApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPostRepository, PostRepository>();
            services.AddScoped<IGoalRepository, GoalRepository>();

            // Services
            services.AddScoped<IPostService, PostService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGoalService, GoalService>();
        }
    }
}
