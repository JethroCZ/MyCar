using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.DAL.Uow
{
    public interface IAppUnitOfWorkProvider : IEntityFrameworkUnitOfWorkProvider<AppDbContext>
    {
    }
}