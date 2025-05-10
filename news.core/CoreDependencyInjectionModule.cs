using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using news.core.Repositories;
using news.core.Repositories.Interfaces;
using news.core.Services;
using news.core.Services.Interfaces;
using news.domain.Contexts;

namespace news.core
{
    public static class CoreDependencyInjectionModule
    {
        public static IServiceCollection AddCoreDependencyInjectionModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITagService, TagService>();
            services.AddScoped<INewService, NewService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<INewRepository, NewRepository>();

            return services;
        }
    }
}
