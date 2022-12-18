using HakatonApi.Extensions.AddServiceFromAttribute;
using System.Linq.Expressions;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext context;
    public UnitOfWork(AppDbContext _context)
    {
        context = _context;
    }

    private ICourseRepository? _courseRepository;
    public ICourseRepository CourseRepository
    {
        get
        {
            if (_courseRepository is null) _courseRepository = new CourseRepository(context);
            return _courseRepository;
        }
    }

    private IHomeWorkRepository _homeWorkRepository;
    public IHomeWorkRepository HomeWorkRepository
    {
        get
        {
            if (_homeWorkRepository is null) _homeWorkRepository = new HomeWorkRepository(context);
            return _homeWorkRepository;
        }
    }

    private ICourseUserRepository? _userCourseRepository;
    public ICourseUserRepository CourseUserRepository
    {
        get
        {
            if (_userCourseRepository is null) 
                _userCourseRepository = new CourseUserRepository(context);

            return (_userCourseRepository);
        }
    }

    private IUserRepository _userRepository;
    public IUserRepository UserRepository
    {
        get
        {
            if (_userRepository is null) _userRepository =  new UserRepository(context);
            return _userRepository;
        }
    }

    private IResultRepository _resultRepository;
    public IResultRepository ResultRepository
    {
        get
        {
            if (_resultRepository is null) _resultRepository = new ResultRepository(context);
            return _resultRepository;
        }
    }

    public int Save() => context.SaveChanges();

    public Task<int> SaveAsync() => context.SaveChangesAsync();

    public void Dispose()
    {
        context.Dispose();
        GC.SuppressFinalize(this);
    }
}
