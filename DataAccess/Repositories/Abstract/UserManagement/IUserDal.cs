using Core.DataAccess;
using Domain.Entities;

namespace DataAccess.Repositories.Abstract.UserManagement;

public interface IUserDal : IEntityRepository<User>
{
}