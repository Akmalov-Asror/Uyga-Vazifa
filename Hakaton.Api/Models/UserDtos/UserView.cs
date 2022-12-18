namespace HakatonApi.Models.UserDtos;

public class UserView
{
    public Guid Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public IFormFile? UserImage { get; set; }
}