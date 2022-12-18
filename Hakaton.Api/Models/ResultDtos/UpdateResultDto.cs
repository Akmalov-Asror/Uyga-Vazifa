using HakatonApi.Entities;

namespace HakatonApi.Models.ResultDtos;

public class UpdateResultDto
{
    public Guid Id { get; set; }
    public int? Score { get; set; }
    public EUserTaskStatus ResultStatus { get; set; }
    public IFormFile? StudentFile { get; set; }
}