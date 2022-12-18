using HakatonApi.Entities;
using HakatonApi.Models;
using HakatonApi.Models.UserDtos;

namespace HakatonApi.Services.Interfaces;

public interface IAccountService
{
    Task AddUser (SignUpUserDto signUpUserDto);
    User? GetUser(Guid Id);
    void DeleteAccount(User user);
    void UpdateAccount(Guid userId, UpdateUserDto updateUserDto);
}