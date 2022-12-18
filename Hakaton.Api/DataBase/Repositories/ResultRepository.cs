using HakatonApi.Entities;

namespace HakatonApi.DataBase.Repositories;

public class ResultRepository : GenericRepository<Result>, IResultRepository
{
    public ResultRepository (AppDbContext context) : base (context) { }
}