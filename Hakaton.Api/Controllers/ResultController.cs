using HakatonApi.Entities;
using HakatonApi.Models.ResultDtos;
using HakatonApi.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HakatonApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ResultController : ControllerBase
{
    private readonly IResultService resultService;

    private readonly UserManager<User> userManager;
    public ResultController(IResultService resultService,
    IFileHelperService fileHelperService,
            UserManager<User> userManager)
    {
        this.resultService = resultService;
        this.userManager = userManager;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ResultView), StatusCodes.Status200OK)]
    public async Task<ResultView> AddAsync(CreateResultDto createResultDto)
    {
        var user = await userManager.GetUserAsync(User);
        return await resultService.AddResult(user.Id, createResultDto);
    }

    [HttpGet("all")]
    public async Task<List<ResultView>> GetResults(Guid homeworkId)
    {
        return await resultService.GetResults(homeworkId);
    }

    [HttpGet("Id")]
    public async Task GetResultById(Guid resultId)
    {
        await resultService.GetResultById(resultId);
    }

    [HttpDelete]
    public async Task DeleteResult(Guid resultId)
    {
        await resultService.DeleteResult(resultId);
    }

    [HttpPut]
    public async Task Updateresult(UpdateResultDto updateResultDto)
    {
        await resultService.UpdateResult(updateResultDto);
    }
}
