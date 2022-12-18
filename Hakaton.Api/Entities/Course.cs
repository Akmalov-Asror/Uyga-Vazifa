namespace HakatonApi.Entities;

public class Course
{
    public Guid Id { get; set; }
    public Guid Key { get; set; }
    public string? CourseName { get; set; }
    public virtual List<CourseUser>? CourseUsers { get; set; }
    public virtual List<HomeWork>? HomeWorks { get; set; }

}