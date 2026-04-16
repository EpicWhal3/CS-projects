using Application.AdminServices;
using Application.UserServices;
using Lab5.Application.Contracts.Admin;
using Lab5.Application.Contracts.User;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddApplication(this IServiceCollection collection)
    {
        collection.AddScoped<IUserLoginService, UserLoginService>();
        collection.AddScoped<IAdminLoginService, AdminLoginService>();
        collection.AddScoped<UserService>();
        collection.AddScoped<IUserServices>(
            p => p.GetRequiredService<UserService>());

        return collection;
    }
}