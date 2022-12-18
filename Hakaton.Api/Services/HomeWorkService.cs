using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Models.HomeWorkDtos;
using HakatonApi.Services.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace HakatonApi.Services;

[Scoped]
public class HomeWorkService : IHomeWorkService
{
    private readonly IUnitOfWork context;
    private readonly IFileHelperService fileHelperService;
    public HomeWorkService(IUnitOfWork context, IFileHelperService fileHelperService)
    {
        this.context = context;
        this.fileHelperService = fileHelperService;
    }

    public async Task<HomeWorkView> CreateHomeWork(Guid courseId, CreateHomeWorkDto createHomeWorkDto)
    {
        var filePath = await fileHelperService.SaveFileAsync(createHomeWorkDto.File!,EFileType.Files, EFileFolder.HomeWork);
        var homeWork = new HomeWork 
        {
            TaskDescription = createHomeWorkDto.TaskDescription,
            TaskName = createHomeWorkDto.TaskName,
            CourseId = courseId,
            StartDate = createHomeWorkDto.StartDate,
            EndDate = createHomeWorkDto.EndDate,
            FilePath = filePath
            
        }; 
        await  context.HomeWorkRepository.AddAsync(homeWork);
        return homeWork.Adapt<HomeWorkView>();
    }

    public async Task DeleteHomeWork(Guid courseId, Guid homeWorkId)
    {
        var homeWork = context.HomeWorkRepository.GetById(homeWorkId);
        if (homeWork is null) throw new Exception();
        await context.HomeWorkRepository.Remove(homeWork);
    }

    public async  Task<HomeWorkView> GetHomeWorkById(Guid homeWorkId)
    {
        var homeWork = context.HomeWorkRepository.GetById(homeWorkId);
        if (homeWork is null) throw new Exception();
        else return homeWork.Adapt<HomeWorkView>();
    }

    public async Task<List<HomeWorkView>> GetHomeWorks()
    {
        var allHomeWorks = await context.HomeWorkRepository.GetAll().ToListAsync();
        return allHomeWorks.Select(homework => homework.Adapt<HomeWorkView>()).ToList();
    }

    public async Task<HomeWorkView> UpdateHomeWork(UpdateHomeWorkDto updateHomeWorkDto)
    {
        var homeWork = context.HomeWorkRepository.GetById(updateHomeWorkDto.Id);
        if (homeWork is null) throw new Exception();
        var homework = updateHomeWorkDto.Adapt<HomeWork>();
        await context.HomeWorkRepository.Update(homework);
        return homework.Adapt<HomeWorkView>();
    }
}