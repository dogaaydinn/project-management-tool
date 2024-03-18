using Core.Utils.DI;
using Core.Utils.Seed;
using DataAccess.Context.EntityFramework;
using DataAccess.Repositories.Abstract.Association;
using DataAccess.Repositories.Abstract.Communication;
using DataAccess.Repositories.Abstract.ProjectManagement;
using DataAccess.Repositories.Abstract.TaskManagement;
using DataAccess.Repositories.Abstract.UserManagement;
using DataAccess.Repositories.Concrete.EntityFramework.Association;
using DataAccess.Repositories.Concrete.EntityFramework.Communication;
using DataAccess.Repositories.Concrete.EntityFramework.ProjectManagement;
using DataAccess.Repositories.Concrete.EntityFramework.TaskManagement;
using DataAccess.Repositories.Concrete.EntityFramework.UserManagement;
using DataAccess.Utils.Seed.EntityFramework;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess.DependencyResolvers;

public class DataAccessModule : IDependencyInjectionModule
{
    public void Load(IServiceCollection services)
    {
        #region DbContext

        services.AddDbContext<EfDbContext>();

        #endregion DbContext

        #region Repositories

        services.AddScoped<IProjectDal, EfProjectDal>();
        services.AddScoped<ITeamDal, EfTeamDal>();
        services.AddScoped<ITeamProjectDal, EfTeamProjectDal>();
        services.AddScoped<ITaskAccessDal, EfTaskAccessDal>();
        services.AddScoped<ITaskDal, EfTaskDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IUserTaskDal, EfUserTaskDal>();
        services.AddScoped<IAttachmentDal, EfAttachmentDal>();
        services.AddScoped<ICommentDal, EfCommentDal>();
        services.AddScoped<ILabelDal, EfLabelDal>();

        #endregion Repositories

        #region Utils

        services.AddScoped(typeof(ISeeder), typeof(EfSeeder));

        #endregion Utils
    }
}