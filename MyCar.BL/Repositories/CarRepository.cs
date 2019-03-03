using MyCar.DAL.Entities;
using MyCar.DAL.Uow;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.BL.Repositories
{
    public class CarRepository : AppRepository<Car, int>
    {
        public CarRepository(IAppUnitOfWorkProvider unitOfWorkProvider, IDateTimeProvider dateTimeProvider)
            : base(unitOfWorkProvider, dateTimeProvider)
        {
        }
    }
}