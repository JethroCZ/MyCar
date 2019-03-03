using System.Linq;
using MyCar.BL.Dto;
using MyCar.BL.Interfaces.Queries;
using MyCar.BL.Interfaces.Queries.FirstLevel;
using MyCar.DAL.Uow;

namespace MyCar.BL.Queries
{
    public class UserQuery : AppQueryBase<UserDto>, IUserQuery
    {
        private readonly IAppFirstLevelQuery<UserDto> m_appFirstLevelQuery;

        public UserQuery(IAppFirstLevelQuery<UserDto> appFirstLevelQuery, IAppUnitOfWorkProvider unitOfWorkProvider)
            : base(unitOfWorkProvider)
        {
            m_appFirstLevelQuery = appFirstLevelQuery;
        }

        protected override IQueryable<UserDto> GetQueryable()
        {
            return m_appFirstLevelQuery.GetEntitySet().Select(e => new UserDto
            {
                Id = e.Id,
                Jmeno = e.Jmeno,
                Prijmeni = e.Prijmeni
            });
        }
    }
}