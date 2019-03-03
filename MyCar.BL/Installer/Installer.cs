using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using MyCar.BL.Interfaces.Queries.FirstLevel;
using MyCar.BL.Interfaces.Repositories;
using MyCar.BL.Queries;
using MyCar.BL.Queries.FirstLevel;
using MyCar.BL.Repositories;
using Riganti.Utils.Infrastructure.Core;

namespace MyCar.BL.Installer
{
    public class Installer : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            System.Diagnostics.Debug.WriteLine("---->>> Installer BL");

            var blAssembly = typeof(Installer).Assembly;

            var dateTime = Component.For<IDateTimeProvider>()
                .ImplementedBy<UtcDateTimeProvider>()
                .LifestyleSingleton();
            container.Register(dateTime);

            var repository = Component.For(typeof(IAppRepository<,>))
                .ImplementedBy(typeof(AppRepository<,>))
                .LifestyleSingleton();
            container.Register(repository);

            var repositories = Classes.FromAssembly(blAssembly)
                .BasedOn(typeof(AppRepository<,>))
                .WithServiceAllInterfaces()
                .LifestyleSingleton();
            container.Register(repositories);

            var appFirstLevelQuery = Component.For(typeof(IAppFirstLevelQuery<>))
                .ImplementedBy(typeof(AppFirstLevelQuery<>))
                .LifestyleTransient();
            container.Register(appFirstLevelQuery);

            var firstLevelQueries = Classes.FromAssembly(blAssembly)
                .BasedOn(typeof(IAppFirstLevelQuery<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient();
            container.Register(firstLevelQueries);

            var queries = Classes.FromAssembly(blAssembly)
                .BasedOn(typeof(AppQueryBase<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient();
            container.Register(queries);
        }
    }
}