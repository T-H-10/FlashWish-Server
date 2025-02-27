using FlashWish.Core;
using FlashWish.Core.IServices;
using FlashWish.Core.Repositories;
using FlashWish.Data;
using FlashWish.Data.Repositories;
using FlashWish.Service.Services;

namespace FlashWish.API
{
    public static class ExtensionDependency
    {
        public static void addDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddControllers();
            services.AddSingleton<DataContext>();

            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));
        }
    }
}
