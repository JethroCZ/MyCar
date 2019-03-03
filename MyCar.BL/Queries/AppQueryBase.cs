using MyCar.BL.Interfaces.Queries;
using MyCar.DAL;
using MyCar.DAL.Uow;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.BL.Queries
{
    public abstract class AppQueryBase<TResult> : EntityFrameworkQuery<TResult, AppDbContext>, IAppQuery<TResult>
    {
        protected AppQueryBase(IAppUnitOfWorkProvider unitOfWorkProvider)
            : base(unitOfWorkProvider)
        {
        }
    }
}