using Microsoft.AspNetCore.Identity;

namespace HakatonApi.Entities;

public class User : IdentityUser<Guid>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Password { get; set; }
    public virtual List<Result>? HomeWorks { get; set; }
    public string? AvatarUrl { get; set; }
}