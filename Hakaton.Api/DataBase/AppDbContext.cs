using HakatonApi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.DataBase;

public class AppDbContext : IdentityDbContext<User, Role, Guid>
{
    public DbSet<Result>? Results { get; set; }
    public DbSet<HomeWork>? HomeWorks { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Result> Result { get; set; }
    public DbSet<CourseUser> CourseUsers { get; set; }
    public AppDbContext(DbContextOptions options) : base(options) { }

   protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        var userId = Guid.NewGuid();
        var courseId = Guid.NewGuid();
        var homeWorkId1 = Guid.NewGuid();
        var homeWorkId2 = Guid.NewGuid();

        builder.Entity<User>().HasData(new List<User>
        {
            new User
            {
                Id        = userId,
                UserName  = "Abdurauf",
                FirstName = "Abdurauf",
                LastName  = "Makhammatov",
            }
        });

        builder.Entity<HomeWork>().HasData(new List<HomeWork>
        {
            new HomeWork
            {
                Id = homeWorkId1,
                TaskName = "50 ta listga referat yozib keling",
                TaskDescription ="bahonalar o`tmaydi, hatto spravka ham",
                MaxScore = 100,
                Status = Entities.ETaskStatus.Created,
                CourseId = courseId
            },

            new HomeWork
            {
                Id = homeWorkId2,
                TaskName = "50 ta listga referat yozib keling",
                TaskDescription ="bahonalar o`tmaydi, hatto spravka ham",
                MaxScore = 100,
                Status = Entities.ETaskStatus.Created,
                CourseId = courseId
            }
        });

        builder.Entity<Course>().HasData(new List<Course>
        {
            new Course
            {
                Id          = courseId,
                Key         = Guid.NewGuid(),
                CourseName  =  "firstRoom"
            }
        });

        builder.Entity<Result>().HasData(new List<Result>
        {
            new Result
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                HomeWorkId = homeWorkId1,
                Score = 56,
                TeacherComment = "Men yorvorganman",
                StudentComment = "Cut the bullshit",
                ResultStatus = EUserTaskStatus.Rejected,
            },

            new Result
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                HomeWorkId = homeWorkId2,
                TeacherComment = "WOW",
                StudentComment = "In shaa Allah",
                Score = 96,
              
                ResultStatus = EUserTaskStatus.Accepted,
            }
        });

        builder.Entity<CourseUser>().HasData(new List<CourseUser>
        {
            new CourseUser
            {

                 Id       = Guid.NewGuid(),
                 CourseId = courseId,
                 UserId   = userId,
                 IsAdmin = true
            }
        });
    }
}