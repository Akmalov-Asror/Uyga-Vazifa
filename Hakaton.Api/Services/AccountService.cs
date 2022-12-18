using HakatonApi.DataBase.Repositories;
using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;
using HakatonApi.Models;
using HakatonApi.Models.UserDtos;
using HakatonApi.Services.Interfaces;

namespace HakatonApi.Services;

[Scoped]
public class AccountService : IAccountService
{
    private readonly IUnitOfWork context;
    private readonly IFileHelperService fileHelperService;
    public AccountService(IUnitOfWork context, IFileHelperService fileHelperService)
    {
        this.context = context;
        this.fileHelperService = fileHelperService;
    }
       

    public async Task AddUser (SignUpUserDto signUpUserDto)
    {
        var imagepath = await fileHelperService.SaveFileAsync(signUpUserDto.Avatar!,EFileType.Images, EFileFolder.User);
        var user = new User
        {
            UserName = signUpUserDto.UserName,
            FirstName = signUpUserDto.FirstName,
            LastName = signUpUserDto.LastName,
            Password = signUpUserDto.Password,
            AvatarUrl = imagepath
        };
        await context.UserRepository.AddAsync(user);
    }

    public User? GetUser (Guid userId) => context.UserRepository.GetById(userId);

    public void DeleteAccount(User user) => context.UserRepository.Remove(user);

    public void UpdateAccount(Guid userId, UpdateUserDto updateUserDto)
    {
        var user = context.UserRepository.GetById(userId);
        if (user is null) throw new Exception();
        context.UserRepository.Update(user);
    }
}