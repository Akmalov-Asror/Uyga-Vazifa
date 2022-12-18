using HakatonApi.Entities;
using HakatonApi.Extensions.AddServiceFromAttribute;

namespace HakatonApi.DataBase.Repositories;

[Scoped]
public class HomeWorkRepository : GenericRepository<HomeWork>, IHomeWorkRepository
{
    public HomeWorkRepository(AppDbContext context) : base(context) { }
}