using Core.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Task = Domain.Entities.Task;

namespace DataAccess.Context.EntityFramework;

public sealed class EfDbContext : EfDbContextBase.DbContextBase
{
    public EfDbContext() : base()
    {
        ChangeTracker.LazyLoadingEnabled = false;
    }


public EfDbContext(DbContextOptions<EfDbContext> options) : base(options)
{
    ChangeTracker.LazyLoadingEnabled = false;
}

    public DbSet<Project> Projects { get; set; }
    public DbSet<Team> Teams { get; set; }
    public DbSet<TeamProject> TeamProjects { get; set; }
    public DbSet<TaskAccess> TaskAccesses { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
    public DbSet<Attachment> Attachments { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Label> Labels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTask>()
            .HasKey(ut => new { ut.UserId, ut.TaskId });

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTasks)
            .HasForeignKey(ut => ut.UserId);

        modelBuilder.Entity<UserTask>()
            .HasOne(ut => ut.Task)
            .WithMany(t => t.UserTasks)
            .HasForeignKey(ut => ut.TaskId);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Teams)
            .WithOne(t => t.TeamLead)
            .OnDelete(DeleteBehavior.Restrict);

        // Additional configurations for other relationships, if any

        base.OnModelCreating(modelBuilder);
    }
      
}
