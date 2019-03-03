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
    public class GasolineFacade : IGasolineFacade
    {
        private readonly IAppUnitOfWorkProvider m_appUnitOfWorkProvider;
        private readonly IAppRepository<Gasoline, int> m_repository;
        private readonly Func<IGasolineQuery> m_queryFactory;

        public GasolineFacade(
            IAppUnitOfWorkProvider appUnitOfWorkProvider,
            IAppRepository<Gasoline, int> repository,
            Func<IGasolineQuery> queryFactory)
        {
            m_appUnitOfWorkProvider = appUnitOfWorkProvider;
            m_repository = repository;
            m_queryFactory = queryFactory;
        }

        public void Add(GasolineDto gasoline)
        {
            var entity = m_repository.InitializeNew();
            entity.CarId = gasoline.CarId;
            entity.GasolineTanked = gasoline.GasolineTanked;
            entity.Mileage = gasoline.Mileage;
            entity.RefiledDate = gasoline.RefiledDate;

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

        public GasolineDto[] GetGasoline()
        {
            using (m_appUnitOfWorkProvider.Create())
            {
                var query = m_queryFactory();
                return query.Execute().ToArray();
            }
        }
    }
}