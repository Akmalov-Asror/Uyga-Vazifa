using System.ComponentModel.DataAnnotations.Schema;

namespace HakatonApi.Entities;

public class Result
{
    public Guid Id { get; set; }
    public string? StudentComment { get; set; }
    public string? TeacherComment { get; set; }
    public int? Score { get; set; }
    public EUserTaskStatus ResultStatus { get; set; }
    public DateTime? CompletedTime { get; set; }
    public string? FilePath { get; set; }
    public Guid UserId { get; set; }
    [ForeignKey(nameof(UserId))]  
    public virtual User? User { get; set; }

    public Guid HomeWorkId { get; set; }
    [ForeignKey(nameof(HomeWorkId))]
    public virtual HomeWork? HomeWork { get; set; }
}

