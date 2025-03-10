using FlashWish.Core;
using FlashWish.Core.IServices;
using FlashWish.Core.Repositories;
using FlashWish.Data;
using FlashWish.Data.Repositories;
using FlashWish.Service.Services;
using Microsoft.EntityFrameworkCore;

namespace FlashWish.API
{
    public static class ExtensionDependency
    {
        public static void addDependency(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITemplateService, TemplateService>();
            services.AddScoped<IGreetingMessageService, GreetingMessageService>();
            services.AddScoped<IGreetingCardService, GreetingCardService>();
            services.AddScoped<ICategoryService, CategoryService>();

            
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IRepositoryManager, RepositoryManager>();

            services.AddControllers();
            services.AddSingleton<DataContext>();

            services.AddAutoMapper(typeof(MappingProfile), typeof(MappingPostProfile));
            //services.AddDbContext<DataContext>(option =>
            //{
            //    option.UseSqlServer("Data Source = תהילה-הרשלר\\SQLEXPRESS; Inital Catalog = FlashWish1; Integrated Security = true; ");
            //});
        }
    }
}
