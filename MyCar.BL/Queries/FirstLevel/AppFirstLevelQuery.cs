using MyCar.BL.Interfaces.Queries.FirstLevel;
using MyCar.DAL;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.BL.Queries.FirstLevel
{
    public class AppFirstLevelQuery<TEntity> : EntityFrameworkFirstLevelQueryBase<TEntity, AppDbContext>, IAppFirstLevelQuery<TEntity>
    where TEntity : class
    {
        protected AppFirstLevelQuery(IUnitOfWorkProvider unitOfWorkProvider)
            : base(unitOfWorkProvider)
        {
        }
    }
}