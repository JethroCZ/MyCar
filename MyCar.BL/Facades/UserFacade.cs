using System;
using System.Linq;
using MyCar.BL.Dto;
using MyCar.BL.Interfaces.Facades;
using MyCar.BL.Interfaces.Queries;
using MyCar.BL.Interfaces.Repositories;
using MyCar.DAL.Entities;
using MyCar.DAL.Uow;

namespace MyCar.BL.Facades
{
    public class UserFacade : IUserFacade
    {
        private readonly IAppUnitOfWorkProvider m_appUnitOfWorkProvider;
        private readonly IAppRepository<User, int> m_repository;
        private readonly Func<IUserQuery> m_queryFactory;

        public UserFacade(
            IAppUnitOfWorkProvider appUnitOfWorkProvider,
            IAppRepository<User, int> repository,
            Func<IUserQuery> queryFactory)
        {
            m_appUnitOfWorkProvider = appUnitOfWorkProvider;
            m_repository = repository;
            m_queryFactory = queryFactory;
        }

        public void Add(UserDto user)
        {
            var entity = m_repository.InitializeNew();
            entity.Jmeno = user.Jmeno;
            entity.Prijmeni = user.Prijmeni;

            using (var uow = m_appUnitOfWorkProvider.Create())
            {
                m_repository.Insert(entity);
                try
                {
                    uow.Commit();
                }
                catch (Exception e)
                {
                    // Logování erroru
                    throw;
                }
            }
        }

        public UserDto[] GetUsers()
        {
            using (m_appUnitOfWorkProvider.Create())
            {
                var query = m_queryFactory();
                return query.Execute().ToArray();
            }
        }
    }
}