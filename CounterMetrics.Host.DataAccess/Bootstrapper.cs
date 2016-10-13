using System.Data.Entity;
using CounterMetrics.Contracts.DataAccess;
using CounterMetrics.DataAccess;
using CounterMetrics.Infrastructure;
using Microsoft.Practices.Unity;

namespace CounterMetrics.Host.DataAccess
{
    internal class Bootstrapper
    {
        public static UnityContainer Init()
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<ILogger, Logger>();
            unityContainer.RegisterType<IHasher, Hasher>();
            unityContainer.RegisterType<DbContext, DatabaseContext>(new InjectionConstructor("name=CounterMetricsConn"));
            unityContainer.RegisterType<IUserRepository, UserRepository>();
            unityContainer.RegisterType<ICounterRepository, CounterRepository>();
            unityContainer.RegisterInstance<ISessionContextRepository>(
                unityContainer.Resolve<WcfSessionContextRepository>());
            unityContainer.RegisterType<IMetricsStoreRepository, MetricsStoreRepository>();
            unityContainer.RegisterType<IMetricsRetrieveRepository, MetricsRetrieveRepository>();
            unityContainer.RegisterType<IUserRepository, UserRepository>();


            ServiceLocator.Build(unityContainer);
            return unityContainer;
        }
    }
}