using System.Diagnostics;
using Core.Utils.DI;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.DependencyResolvers;

public class CoreModule : IDependencyInjectionModule
{
    public void Load(IServiceCollection services)
    {
        services.AddMemoryCache();
        services.AddSingleton<Stopwatch>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }
}