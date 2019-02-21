using System;
using Riganti.Utils.Infrastructure.Core;
using Riganti.Utils.Infrastructure.EntityFrameworkCore;

namespace MyCar.DAL.Uow
{
    public class AppUnitOfWorkProvider : EntityFrameworkUnitOfWorkProvider<AppDbContext>, IAppUnitOfWorkProvider
    {
        public AppUnitOfWorkProvider(IUnitOfWorkRegistry registry, Func<AppDbContext> dbContextFactory)
            : base(registry, dbContextFactory)
        {
        }
    }
}