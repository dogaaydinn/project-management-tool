using Core.Utils.DI;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers;

public class BusinessModule : IDependencyInjectionModule

{
    public void Load(IServiceCollection services)
    {
        # region Membership

        services.AddScoped<IBusinessService, BusinessManager>();

        # endregion Membership
    }
}