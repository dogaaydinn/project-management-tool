using Core.DataAccess.EntityFramework;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.Communication;
using Domain.Entities;

namespace DataAccess.Repositories.Concrete.EntityFramework.Communication;

public class EfAttachmentDal : EfEntityRepository<Attachment, EfDbContext>, IAttachmentDal
{
}