using Microsoft.AspNetCore.Builder;

namespace Core.Utils.Seed.Abstract;

public interface ISeeder
{
    void Seed(IApplicationBuilder builder);
}