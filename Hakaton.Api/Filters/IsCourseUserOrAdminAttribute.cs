using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Filters
{
    public class IsCourseUserOrAdminAttribute : TypeFilterAttribute
    {
        public IsCourseUserOrAdminAttribute(bool onlyAdmin = false) : base(typeof(CourseAdminFilterAttribute))
        {
            Arguments = new object[] { onlyAdmin };
        }
    }
}
