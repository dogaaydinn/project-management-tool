using Microsoft.Extensions.DependencyInjection;

namespace Core.Utils.IoC;

public static class ServiceTool
{
    private static IServiceProvider ServiceProvider { get; set; } = null!;

    public static IServiceCollection Create(IServiceCollection services)
    {
        ServiceProvider = services.BuildServiceProvider();
        return services;
    }

    public static T? GetService<T>()
    {
        return ServiceProvider.GetService<T>();
    }
}