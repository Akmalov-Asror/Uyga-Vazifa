using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository (AppDbContext context) : base (context) { }
}