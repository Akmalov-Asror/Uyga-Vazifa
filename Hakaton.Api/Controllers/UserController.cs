using HakatonApi.Services.Interfaces;
using HakatonApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HakatonApi.Controllers;

[Route("[controller]")]
[ApiController]
[Authorize]
public class UserController : Controller
{
    private readonly IUserService studentService;
    private readonly UserManager<User> userManager;
    public UserController (IUserService _studentService,
                             UserManager<User> _userManager)
    {
        studentService = _studentService; 
        userManager = _userManager;
    }

    [HttpPost("join")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> JoinToCourse(Guid courseId)
    {
        var user = await userManager.GetUserAsync(User);
        await studentService.JoinToCourse(courseId, user.Id);
        return Ok();
    }

    [HttpGet("leave")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> LeaveCourse(Guid courseId)
    {
        var user = await userManager.GetUserAsync(User);
        await studentService.LeaveCourse(courseId, user.Id);
        return Ok();
    }
}