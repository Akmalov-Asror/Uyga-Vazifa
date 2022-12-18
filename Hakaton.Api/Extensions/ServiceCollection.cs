using HakatonApi.DataBase;
using HakatonApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Extensions;

public static class ServiceCollection
{
    public static void _AddCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddDefaultPolicy(options =>
            {
                options.AllowAnyHeader().AllowAnyOrigin().AllowAnyOrigin();
            });
        });
    }

    public static void _AddDbContext(this IServiceCollection services, string connetionstring)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(connetionstring).UseLazyLoadingProxies();
        });
    }

    public static void _AddIdentity(this IServiceCollection services)
    {
        services.AddIdentity<User, Role>(options =>
        {
            options.Password.RequiredUniqueChars = 1;
            options.Password.RequiredLength = 4;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireDigit = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
        })
                .AddEntityFrameworkStores<AppDbContext>();
    }
}