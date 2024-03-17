using Core.Utils.IoC;
using Core.Utils.Seed.Abstract;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions;

public static class ApplicationBuilderExtensions
{
    public static void UseSeeder(this IApplicationBuilder builder)
    {
        var seeder = ServiceTool.GetService<ISeeder>()!;
        seeder.Seed(builder);
    }
}