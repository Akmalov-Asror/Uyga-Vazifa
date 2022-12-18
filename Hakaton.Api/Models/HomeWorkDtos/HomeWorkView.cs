using TaskStatus = HakatonApi.Entities.TaskStatus;

namespace HakatonApi.Models.HomeWorkDtos;


public class HomeWorkView
{
    public Guid Id { get; set; }
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public int MaxScore { get; set; }
    public FormFile? File { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set;}
}