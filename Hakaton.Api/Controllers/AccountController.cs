using HakatonApi.Entities;
using HakatonApi.Services.Interfaces;
using HakatonApi.Models;
using HakatonApi.Models.UserDtos;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<User> signInManager;
    private readonly UserManager<User> userManager;
    private readonly IAccountService accountService;

    public AccountController(SignInManager<User> signInManager,
                               UserManager<User> userManager,
                               IAccountService accountService)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.accountService = accountService;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> SignUp([FromForm] SignUpUserDto registerUserDto)
    {
        var user = registerUserDto.Adapt<User>();
        var result = await userManager.CreateAsync(user, registerUserDto.Password);

        if (!result.Succeeded)
            return BadRequest();

        await signInManager.SignInAsync(user, true);
        await accountService.AddUser(registerUserDto);
        return Ok(user);
    }

    [HttpPost("signin")]
    public async Task<IActionResult> SignIn([FromForm] SignInUserDto signInUserDto)
    {
        var result = await signInManager.PasswordSignInAsync(signInUserDto.UserName, 
                                                             signInUserDto.Password, true, true);
        if (!result.Succeeded)
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetUser (Guid userId)
    {
        var user = accountService.GetUser(userId);
        if (user is null) return NotFound();
        return Ok(user);
    }

    [HttpPut]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateAccount([FromForm] UpdateUserDto updateUserDto)
    {
        var user = await userManager.GetUserAsync(User);
        accountService.UpdateAccount(user.Id, updateUserDto);
        return Ok();
    }

    [HttpDelete]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteAccount()
    {
        var user = await userManager.GetUserAsync(User);
        accountService.DeleteAccount(user);
        return Ok();
    }
}