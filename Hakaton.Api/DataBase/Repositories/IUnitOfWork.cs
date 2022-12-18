
namespace HakatonApi.DataBase.Repositories;

public interface IUnitOfWork
{
    ICourseRepository CourseRepository { get;}
    ICourseUserRepository CourseUserRepository { get;}
    IUserRepository UserRepository { get;}
    IResultRepository ResultRepository { get;}

    IHomeWorkRepository HomeWorkRepository { get; }
    int Save();
    Task<int> SaveAsync();
}