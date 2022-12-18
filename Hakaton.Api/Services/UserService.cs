using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services;

[Scoped]
public class UserService : IUserService
{
    private readonly IUnitOfWork context;
    public UserService(IUnitOfWork _context) => context = _context;

    public async Task JoinToCourse(Guid courseId, Guid userId)
    {
        var course = context.CourseRepository.GetById(courseId);

        if (course is null)
            throw new Exception("Not Found");

        if (course.CourseUsers!.Any(u => u.UserId == userId))
            throw new Exception("You have already joined");

        course.CourseUsers ??= new List<CourseUser>();
        var courseUser = new CourseUser
        {
            UserId = userId,
            CourseId = course.Id,
            IsAdmin = false
        };

        await context.CourseUserRepository.AddAsync(courseUser);
        await context.SaveAsync();
    }

    public async Task LeaveCourse(Guid courseId, Guid userId)
    {
        var courseUsers =await  context.CourseUserRepository.GetAll().ToListAsync();
        var currentCourseUser = courseUsers.FirstOrDefault(u => u.UserId == userId);

        if (currentCourseUser is null) throw new Exception("you are not member of this course");
        await context.CourseUserRepository.Remove(currentCourseUser);
    }
}