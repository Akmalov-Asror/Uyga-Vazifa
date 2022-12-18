using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class UserRepository : GenericRepository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context) { }
}