using System.Linq;
using MyCar.BL.Dto;
using MyCar.BL.Interfaces.Queries;
using MyCar.BL.Interfaces.Queries.FirstLevel;
using MyCar.DAL.Uow;

namespace MyCar.BL.Queries
{
    public class GasolineQuery : AppQueryBase<GasolineDto>, IGasolineQuery
    {
        private readonly IAppFirstLevelQuery<GasolineDto> m_appFirstLevelQuery;

        public GasolineQuery(IAppFirstLevelQuery<GasolineDto> appFirstLevelQuery,IAppUnitOfWorkProvider unitOfWorkProvider)
            : base(unitOfWorkProvider)
        {
            m_appFirstLevelQuery = appFirstLevelQuery;
        }

        protected override IQueryable<GasolineDto> GetQueryable()
        {
            return m_appFirstLevelQuery.GetEntitySet().Select(e => new GasolineDto
            {
                Id = e.Id,
                CarId = e.CarId,
                GasolineTanked = e.GasolineTanked,
                Mileage = e.Mileage,
                RefiledDate = e.RefiledDate
            });
        }
    }
}