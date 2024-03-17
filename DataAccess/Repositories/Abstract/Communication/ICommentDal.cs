using Core.DataAccess;
using Domain.Entities;

namespace DataAccess.Repositories.Abstract.Communication;

public interface ICommentDal : IEntityRepository<Comment>
{
}