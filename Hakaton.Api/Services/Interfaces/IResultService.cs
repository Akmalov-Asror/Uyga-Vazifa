using HakatonApi.Entities;
using HakatonApi.Models.ResultDtos;

namespace HakatonApi.Services.Interfaces;

public interface IResultService
{
    Task<ResultView> AddResult(Guid userId, CreateResultDto createResultDto);
    Task<ResultView> GetResultById(Guid ID);
    Task DeleteResult (Guid Id);
    Task UpdateResult(UpdateResultDto updateResultDto);
    Task<List<ResultView>> GetResults(Guid homeworkId);
}