using Microsoft.Extensions.DependencyInjection;

namespace Core.Utils.DI;

public interface IDependencyInjectionModule
{
    void Load(IServiceCollection services);
}