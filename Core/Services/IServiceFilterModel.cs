using Core.Models.Entities.Abstract;

namespace Core.Services;

public interface IServiceFilterModel<T> where T : class, IEntity, new()
{
}