using HakatonApi.Models.HomeWorkDtos;
using HakatonApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class HomeWorkController : ControllerBase
{
    private readonly IHomeWorkService homeWorkService;
    public HomeWorkController(IHomeWorkService homeWorkService) => this.homeWorkService = homeWorkService ;

    [HttpPost]
    [ProducesResponseType(typeof(HomeWorkView),StatusCodes.Status200OK)]
    public async Task<IActionResult> CreateHomeWork(Guid courseId,[FromForm] CreateHomeWorkDto createHomeWorkDto)
    {
        var homeWorkView = await homeWorkService.CreateHomeWork(courseId, createHomeWorkDto);
        return Ok(homeWorkView);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteHomeWork(Guid courseId, Guid homeWorkId)
    {
        await homeWorkService.DeleteHomeWork(courseId, homeWorkId);
        return Ok();
    }

    [HttpGet("id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHomeWorkById(Guid homeWorkId)
    {
        var homework  = await homeWorkService.GetHomeWorkById(homeWorkId);
        return Ok(homework);
    }

    [HttpGet("all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetHomeWorks()
    {
        var homeWorks = await  homeWorkService.GetHomeWorks();
        return Ok(homeWorks);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateHomeWork(UpdateHomeWorkDto updateHomeWorkDto)
    {
        await homeWorkService.UpdateHomeWork(updateHomeWorkDto);
        return Ok();
    }
}