using HakatonApi.Models.CourseDtos;
using HakatonApi.Entities;
using HakatonApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("Api.[controller]")]
[ApiController]
[Authorize]
public class CourseController : ControllerBase
{
    private readonly ICourseService courseService;
    private readonly UserManager<User> userManager;
    public CourseController(ICourseService _courseService, UserManager<User> _userManager)
    {
        courseService = _courseService;
        userManager = _userManager;
    }

    [HttpPost]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateCourse([FromForm]CreateCourseDto getCourseDto)
    {
        var user = await userManager.GetUserAsync(User);
        var courseId = await courseService.CreateCourse(user.Id, getCourseDto);
        return Ok(courseId);
    }

    [HttpGet("courseId")]
    [ProducesResponseType(typeof(CourseView), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourseById(Guid courseId) => 
        Ok(await courseService.GetCourseById(courseId));

    [HttpGet("all")]
    [ProducesResponseType(typeof(List<CourseView>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourses() =>
        Ok(await courseService.GetCourses());

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateCourse([FromForm]UpdateCourseDto updateCourseDto)
    {
        var user = await userManager.GetUserAsync(User);
        await courseService.UpdateCourse(updateCourseDto);
        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteCourse(Guid courseId)
    {
        await courseService.DeleteCourse(courseId);
        return Ok();
    }

    [HttpGet("members")]
    [ProducesResponseType(typeof(List<User>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCourseMembers(Guid courseId)
    {
        var members = await courseService.GetCourseMembers(courseId);
        return Ok(members);
    }
}