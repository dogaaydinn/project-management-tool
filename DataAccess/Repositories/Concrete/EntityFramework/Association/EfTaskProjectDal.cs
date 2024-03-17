using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.Association;
using Domain.Entities;

namespace DataAccess.Repositories.Concrete.EntityFramework.Association;

public class EfTaskProjectDal : EfEntityRepository<TeamProject, EfDbContext>, ITaskProjectDal
{
}