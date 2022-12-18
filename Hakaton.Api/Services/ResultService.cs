using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Models.ResultDtos;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services;

public class ResultService : IResultService
{
    private readonly IUnitOfWork context;
    private readonly IFileHelperService fileHelperService;
    public ResultService(IUnitOfWork context, IFileHelperService fileHelperService)
    {
        this.context = context;
        this.fileHelperService = fileHelperService;
    }

    public async Task<ResultView> AddResult(Guid userId, CreateResultDto createResultDto)
    {
        var filepath = await fileHelperService.SaveFileAsync(createResultDto.StudentFile, EFileType.Files, EFileFolder.HomeWork);
        var result = new Result
        {
            Score = createResultDto.Score,
            ResultStatus = createResultDto.ResultStatus,
            UserId = userId,
            FilePath = filepath,
        };
        await context.ResultRepository.AddAsync(result);
        return result.Adapt<ResultView>();
    }

    public async Task DeleteResult(Guid resultId)
    {
        var result = context.ResultRepository.GetById(resultId);
        if (result is null) throw new Exception("not found result");
        await context.ResultRepository.Remove(result);
    }

    public async Task<ResultView> GetResultById(Guid resultId)
    {
        var result = context.ResultRepository.GetById(resultId);
        if (result is null) throw new Exception("not found result");
        return result.Adapt<ResultView>();
    }

    public async Task<List<ResultView>> GetResults(Guid homeworkId)
    {
        var allResults = context.ResultRepository.GetAll().Where(result => result.HomeWorkId == homeworkId);
        var results = await allResults.ToListAsync();
        return results.Select(result => results.Adapt<ResultView>()).ToList();
    }

    public async Task UpdateResult(UpdateResultDto updateResultDto)
    {
        var result = context.ResultRepository.GetById(updateResultDto.Id);
        if (result is null) throw new Exception("not found result");
        result.Score = updateResultDto.Score;
        await context.SaveAsync();
    }
}