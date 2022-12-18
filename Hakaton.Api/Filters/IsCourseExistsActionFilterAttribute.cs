using HakatonApi.DataBase;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Filters;

public class IsCourseExistsActionFilterAttribute : ActionFilterAttribute
{
    private readonly AppDbContext _context;

    public IsCourseExistsActionFilterAttribute(AppDbContext context)
    {
        _context = context;
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.ActionArguments.ContainsKey("courseId"))
        {
            await next();
            return;
        }

        var courseId = (Guid?)context.ActionArguments["courseId"];

        if (!await _context.Courses.AnyAsync(course => course.Id == courseId))
        {
            context.Result = new NotFoundResult();
            return;
        }

        await next();
    }
}