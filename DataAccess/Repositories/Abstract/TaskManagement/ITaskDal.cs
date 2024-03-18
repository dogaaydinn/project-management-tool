using Core.DataAccess;
using Task = Domain.Entities.Task;

namespace DataAccess.Repositories.Abstract.TaskManagement;

public interface ITaskDal : IEntityRepository<Task>
{
}