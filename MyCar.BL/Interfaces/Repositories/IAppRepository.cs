using MyCar.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.BL.Interfaces.Repositories
{
    public interface IAppRepository<TEntity, in TKey> : IEntityFrameworkRepository<TEntity, TKey, AppDbContext>
        where TEntity : IEntity<TKey>
    {
        
    }
}