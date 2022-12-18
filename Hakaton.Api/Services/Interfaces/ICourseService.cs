using HakatonApi.Entities;
using HakatonApi.Models.CourseDtos;

namespace HakatonApi.Services.Interfaces;

public interface ICourseService
{
    Task<Guid> CreateCourse(Guid userId, CreateCourseDto createCource);
    Task<CourseView> GetCourseById(Guid courseId);
    Task<List<CourseView>> GetCourses();
    Task UpdateCourse(UpdateCourseDto updateCourceDto);
    Task DeleteCourse(Guid courseId);
    Task<List<User>> GetCourseMembers(Guid courseId);
}