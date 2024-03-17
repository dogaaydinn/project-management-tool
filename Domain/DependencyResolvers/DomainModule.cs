using Core.Utils.DI;

using Microsoft.Extensions.DependencyInjection;

namespace Domain.DependencyResolvers;

public class DomainModule : IDependencyInjectionModule
{
    public void Load(IServiceCollection services)
    {
        #region Auto Mapper

      //  services.AddAutoMapper(typeof(DomainModule));

        #endregion Auto Mapper
    }
}