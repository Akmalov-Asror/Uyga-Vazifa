using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class CourseUserRepository : GenericRepository<CourseUser>, ICourseUserRepository
{
    public CourseUserRepository(AppDbContext context) : base (context) { }
}
