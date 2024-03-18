using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.TaskManagement;
using Task = Domain.Entities.Task;

namespace DataAccess.Repositories.Concrete.EntityFramework.TaskManagement;

public class EfTaskDal : EfEntityRepository<Task, EfDbContext>, ITaskDal
{
}