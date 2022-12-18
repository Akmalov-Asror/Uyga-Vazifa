using HakatonApi.Entities;

namespace HakatonApi.Models.ResultDtos;

public class ResultView
{
    public Guid Id { get; set; }
    public string? StudentComment { get; set; }
    public string? TeacherComment { get; set; }
    public int? Score { get; set; }
    public EUserTaskStatus ResultStatus { get; set; }
    public DateTime? CompletedTime { get; set; }
    public IFormFile? StudentFile { get; set; }
}