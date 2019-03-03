using MyCar.DAL;
using MyCar.DAL.Uow;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.BL.Repositories
{
    public class AppRepository<TEntity, TKey> : EntityFrameworkRepository<TEntity, TKey, AppDbContext>, IAppRepository<TEntity, TKey>
    where TEntity : class, IEntity<TKey>, new()
    {
        public AppRepository(IAppUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}