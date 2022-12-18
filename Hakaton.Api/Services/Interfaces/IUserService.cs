using HakatonApi.Models.UserDtos;
using HakatonApi.Entities;

namespace HakatonApi.Services.Interfaces;

public interface IUserService 
{
    Task LeaveCourse(Guid courseId, Guid userId);
    Task JoinToCourse(Guid courseId, Guid userId);
}