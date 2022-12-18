namespace HakatonApi.Models.CourseDtos;

public class UpdateCourseDto
{
    public Guid courseId { get; set; }
    public string? CourseName { get; set; }
}