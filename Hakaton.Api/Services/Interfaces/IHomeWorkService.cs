using HakatonApi.Models.HomeWorkDtos;

namespace HakatonApi.Services.Interfaces;

public interface IHomeWorkService
{
    Task<HomeWorkView> CreateHomeWork(Guid courseId,CreateHomeWorkDto createHomeWorkDto);
    Task<List<HomeWorkView>> GetHomeWorks();
    Task<HomeWorkView> GetHomeWorkById(Guid homeWorkId);
    Task<HomeWorkView> UpdateHomeWork(UpdateHomeWorkDto updateHomeWorkDto);
    Task DeleteHomeWork(Guid courseId, Guid homeWorkId);
}