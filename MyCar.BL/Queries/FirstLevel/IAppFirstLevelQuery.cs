using MyCar.DAL;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.BL.Queries.FirstLevel
{
    public interface IAppFirstLevelQuery<out TResult> : IEntityFrameworkFirstLevelQuery<TResult, AppDbContext>
    {
        
    }
}