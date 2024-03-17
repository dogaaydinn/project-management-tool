using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.TaskManagement;
using Domain.Entities;

namespace DataAccess.Repositories.Concrete.EntityFramework.TaskManagement;

public class EfLabelDal : EfEntityRepository<Label, EfDbContext>, ILabelDal
{
}