
using Core.Utils.Seed;
using DataAccess.Context.EntityFramework;
using Domain.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Task = System.Threading.Tasks.Task;

namespace DataAccess.Utils.Seed.EntityFramework;

public class EfSeeder : ISeeder
{
    public void Seed(IApplicationBuilder builder)
    {
        var context = builder.ApplicationServices
            .CreateScope().ServiceProvider
            .GetRequiredService<EfDbContext>();

        if (context.Database.GetPendingMigrations().Any())
            context.Database.Migrate();

        // If there is no data in the database, then seed the database
        if (context.Category.Any())
            return;

        #region Team

        var team1 = new Team
        {
            TeamName = "Team Alpha",
            Description = "This is team Alpha."
        };

        var team2 = new Team
        {
            TeamName = "Team Beta",
            Description = "This is team Beta."
        };

        var teams = new List<Team> { team1, team2 };

        #endregion Team
        
        #region UserTeam

        var userTeam1 = new UserTeam
        {
            UserId = user1.UserId,
            TeamId = team1.TeamId
        };

        var userTeam2 = new UserTeam
        {
            UserId = user2.UserId,
            TeamId = team2.TeamId
        };

        var userTeams = new List<UserTeam> { userTeam1, userTeam2 };

        #endregion UserTeam
        #region Project

        var project1 = new Project
        {
            ProjectName = "Project Alpha",
            Description = "This is project Alpha."
        };

        var project2 = new Project
        {
            ProjectName = "Project Beta",
            Description = "This is project Beta."
        };

        var projects = new List<Project> { project1, project2 };

        #endregion Project
        
        #region Task

        var task1 = new Task
        {
            TaskName = "Task Alpha",
            Description = "This is task Alpha.",
            ProjectId = project1.ProjectId
        };

        var task2 = new Task
        {
            TaskName = "Task Beta",
            Description = "This is task Beta.",
            ProjectId = project2.ProjectId
        };

        var tasks = new List<Task> { task1, task2 };

        #endregion Task
        
        #region Label

        var label1 = new Label
        {
            LabelName = "Label Alpha",
            Description = "This is label Alpha.",
            Color = "#FF0000" // Red
        };

        var label2 = new Label
        {
            LabelName = "Label Beta",
            Description = "This is label Beta.",
            Color = "#00FF00" // Green
        };

        var labels = new List<Label> { label1, label2 };

        #endregion Label
        
        /*#region UserLabel

        var userLabel1 = new UserLabel
        {
            UserId = user1.UserId,
            LabelId = label1.LabelId
        };

        var userLabel2 = new UserLabel
        {
            UserId = user2.UserId,
            LabelId = label2.LabelId
        };

        var userLabels = new List<UserLabel> { userLabel1, userLabel2 };

        #endregion UserLabel*/

        #region User

        var user1 = new User
        {
            // Set the properties for user1
        };

        var user2 = new User
        {
            // Set the properties for user2
        };

        var users = new List<User> { user1, user2 };

        #endregion User
        #region TeamProject

        var teamProject1 = new TeamProject
        {
            TeamId = team1.TeamId,
            ProjectId = project1.ProjectId
        };

        var teamProject2 = new TeamProject
        {
            TeamId = team2.TeamId,
            ProjectId = project2.ProjectId
        };

        var teamProjects = new List<TeamProject> { teamProject1, teamProject2 };

        #endregion TeamProject
        #region TaskAccess

        var taskAccess1 = new TaskAccess
        {
            TaskId = task1.TaskId,
            UserId = user1.UserId
        };

        var taskAccess2 = new TaskAccess
        {
            TaskId = task2.TaskId,
            UserId = user2.UserId
        };

        var taskAccesses = new List<TaskAccess> { taskAccess1, taskAccess2 };

        #endregion TaskAccess
        #region Comment

        var comment1 = new Comment
        {
            // Set the properties for comment1
        };

        var comment2 = new Comment
        {
            // Set the properties for comment2
        };

        var comments = new List<Comment> { comment1, comment2 };

        #endregion Comment
        #region Attachment

        var attachment1 = new Attachment
        {
            // Set the properties for attachment1
        };

        var attachment2 = new Attachment
        {
            // Set the properties for attachment2
        };

        var attachments = new List<Attachment> { attachment1, attachment2 };

        #endregion Attachment
        #region UserTask

        var userTask1 = new UserTask
        {
            UserId = user1.UserId,
            TaskId = task1.TaskId
        };

        var userTask2 = new UserTask
        {
            UserId = user2.UserId,
            TaskId = task2.TaskId
        };

        var userTasks = new List<UserTask> { userTask1, userTask2 };

        #endregion UserTask

        context.UserTask.AddRange(userTasks);
        context.SaveChanges();

        context.Attachment.AddRange(attachments);
        context.SaveChanges();

        context.Comment.AddRange(comments);
        context.SaveChanges();

        context.TaskAccess.AddRange(taskAccesses);
        context.SaveChanges();

        context.TeamProject.AddRange(teamProjects);
        context.SaveChanges();

        context.User.AddRange(users);
        context.SaveChanges();

        context.UserTeam.AddRange(userTeams);
        context.SaveChanges();

        // context.UserLabel.AddRange(userLabels);
        // context.SaveChanges();

        context.Label.AddRange(labels);
        context.SaveChanges();

        context.Task.AddRange(tasks);
        context.SaveChanges();

        context.Project.AddRange(projects);
        context.SaveChanges();

        context.Team.AddRange(teams);
        context.SaveChanges();
    }
}