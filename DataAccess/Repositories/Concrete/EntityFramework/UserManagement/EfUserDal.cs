using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.UserManagement;
using Domain.Entities;

namespace DataAccess.Repositories.Concrete.EntityFramework.UserManagement;

public class EfUserDal : EfEntityRepository<User, EfDbContext>, IUserDal
{
}