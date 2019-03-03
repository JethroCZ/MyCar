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
    public class CarFacade : ICarFacade
    {
        private readonly IAppUnitOfWorkProvider m_appUnitOfWorkProvider;
        private readonly IAppRepository<Car, int> m_repository;
        private readonly Func<ICarQuery> m_queryFactory;

        public CarFacade(
            IAppUnitOfWorkProvider appUnitOfWorkProvider,
            IAppRepository<Car, int> repository,
            Func<ICarQuery> queryFactory)
        {
            m_appUnitOfWorkProvider = appUnitOfWorkProvider;
            m_repository = repository;
            m_queryFactory = queryFactory;
        }

        public void Add(CarDto car)
        {
            var entity = m_repository.InitializeNew();
            entity.UserId = car.UserId;

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

        public CarDto[] GetCars()
        {
            using (m_appUnitOfWorkProvider.Create())
            {
                var query = m_queryFactory();
                return query.Execute().ToArray();
            }
        }
    }
}