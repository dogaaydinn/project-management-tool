using Microsoft.AspNetCore.Builder;

namespace Core.Utils.Seed;

public interface ISeeder
{
    void Seed(IApplicationBuilder builder);
}