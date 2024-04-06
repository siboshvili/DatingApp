using System;
using API.Data;
using API.DTOs;
using API.Helpers;
using API.Interface;
using API.Services;
using API.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Exstensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseNpgsql(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.Configure<CloudinarySettings>(config.GetSection("CloudinarySettings"));
        services.AddScoped<IphotoService, PhotoService>();
        services.AddScoped<LogUserActivity>();
        services.AddSignalR();
        services.AddSingleton<PresenceTracker>();
        services.AddScoped<IUnitOfWork, UnitOfWOrk>();

        return services;
    }
}
