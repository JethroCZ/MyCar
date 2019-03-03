using System.Linq;
using MyCar.BL.Dto;
using MyCar.BL.Queries.FirstLevel;
using MyCar.DAL.Entities;
using MyCar.DAL.Uow;

namespace MyCar.BL.Queries
{
    public class CarQuery : AppQueryBase<CarDto>, ICarQuery
    {
        private readonly IAppFirstLevelQuery<Car> m_appFirstLevelQuery;

        public CarQuery(IAppFirstLevelQuery<Car> appFirstLevelQuery,IAppUnitOfWorkProvider unitOfWorkProvider) 
            : base(unitOfWorkProvider)
        {
            m_appFirstLevelQuery = appFirstLevelQuery;
        }

        protected override IQueryable<CarDto> GetQueryable()
        {
            return m_appFirstLevelQuery.GetEntitySet().Select(e => new CarDto
            {
                Id = e.Id,
                UserId = e.UserId
            });
        }
    }
}