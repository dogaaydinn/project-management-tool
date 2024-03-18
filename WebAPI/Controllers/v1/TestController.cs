using DataAccess.Context.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1;

// This is a test controller to make sure that the IoC container and DbContext are working properly.
// After implementing business logic, this controller will be removed.
[ApiController]
[Route("api/v1/[controller]")]
public class TestController : ControllerBase
{
    private readonly EfDbContext _dbContext;

    public TestController(EfDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
}