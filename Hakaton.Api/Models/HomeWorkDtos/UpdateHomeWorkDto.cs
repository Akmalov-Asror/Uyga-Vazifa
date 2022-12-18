
namespace HakatonApi.Models.HomeWorkDtos;

public class UpdateHomeWorkDto
{
    public Guid Id { get; set; }    
    public string? TaskName { get; set; }
    public string? TaskDescription { get; set; }
    public DateTime? EndDate { get; set; }
}