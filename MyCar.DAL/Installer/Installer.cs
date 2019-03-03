using System;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyCar.DAL.Uow;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.DAL.Installer
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            System.Diagnostics.Debug.WriteLine("---->>> Installer DAL");
            var appDbContext = Component.For<Func<AppDbContext>>().Instance(() => new AppDbContext());

            var unitOfWorkRegistry = Component.For<IUnitOfWorkRegistry>()
                .ImplementedBy<AsyncLocalUnitOfWorkRegistry>()
                .LifestyleSingleton();

            var unitOfWorkProvider = Component.For<IAppUnitOfWorkProvider>()
                .ImplementedBy<AppUnitOfWorkProvider>()
                .LifestyleSingleton();

            container.Register(unitOfWorkRegistry, appDbContext, unitOfWorkProvider);
        }
    }
}